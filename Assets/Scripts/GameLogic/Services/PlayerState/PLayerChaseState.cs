using GameLogic.Interfaces;
using Data.Enums;
using GameInfoModels.Interface;
using Models.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace GameLogic.Services
{
    public class PLayerChaseState : PlayerBaseState
    {
        private readonly IEnemyProvider _enemyProvider;
        private readonly IPlayerProvider _playerProvider;
        private readonly float _attackRadius;
        public PLayerChaseState(IEnemyProvider enemyProvider, IPlayerProvider playerProvider, float attackRadius) : base(GameState.Chase)
        {
            _enemyProvider = enemyProvider;
            _playerProvider = playerProvider;
            _attackRadius = attackRadius;
        }
        public override void RunCurrentState()
        {
            foreach (var player in _playerProvider.Units)
            {
                var playerNavMesh = _playerProvider.GetComponent<NavMeshAgent>(player);
                var nearestEnemy = player.TargetToPursue != null
                    ? player.TargetToPursue
                    : FindNearestEnemy(playerNavMesh);

                if (nearestEnemy == null || nearestEnemy.EnemyPosition == Vector3.zero)
                {
                    continue;
                }

                if (playerNavMesh.destination == nearestEnemy.EnemyPosition)
                {
                    continue;
                }

                if (playerNavMesh.SetDestination(nearestEnemy.EnemyPosition))
                {
                    playerNavMesh.stoppingDistance = _attackRadius;
                    player.TargetToPursue = nearestEnemy;
                }
            }
        }
        private IEnemy FindNearestEnemy(NavMeshAgent unit)
        {
            IEnemy nearestEnemy = null;
            float nearestDistance = Mathf.Infinity;
            foreach (IEnemy enemy in _enemyProvider.Enemies)
            {
                var enemyPos = enemy.EnemyObject.transform.position;
                var unitPos = unit.transform.position;
                float distanceToEnemy = Vector3.Distance(unitPos, enemyPos);

                if (distanceToEnemy < nearestDistance)
                {
                    nearestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
            return nearestEnemy;
        }

    }
}
