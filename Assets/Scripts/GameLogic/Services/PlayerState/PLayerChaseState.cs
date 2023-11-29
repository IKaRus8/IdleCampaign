using Assets.Scripts.GameLogic.Interfaces;
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
        private Vector3 lastPosEnemy = Vector3.zero;
        private IEnemy lastNearestEnemy = null;
        private float _attackRadius;
        public PLayerChaseState(IEnemyProvider enemyProvider, IPlayerProvider playerProvider, float attackRadius) : base(GameState.Chase)
        {
            _enemyProvider = enemyProvider;
            _playerProvider = playerProvider;
            _attackRadius = attackRadius;
        }
        public override void RunCurrentState()
        {
            var firstUnit = _playerProvider.Units[0];
            var unitNavMesh = _playerProvider.GetComponent<NavMeshAgent>(firstUnit);
            Vector3 nearestEnemyPos;
            if (lastNearestEnemy == null)
            {
                nearestEnemyPos = FindNearestEnemy(unitNavMesh);
            }
            else
            {
                nearestEnemyPos = lastNearestEnemy.EnemyPosition;
            }
            if (nearestEnemyPos == Vector3.zero)
            {
                return;
            }
            if (lastPosEnemy == nearestEnemyPos)
            {
                return;
            }
            lastPosEnemy = nearestEnemyPos;
            unitNavMesh.SetDestination(nearestEnemyPos);
            unitNavMesh.stoppingDistance = _attackRadius;
        }
        private Vector3 FindNearestEnemy(NavMeshAgent unit)
        {
            Vector3 nearestEnemyVector = Vector3.zero;
            IEnemy nearestEnemy = null;
            float nearestDistance = Mathf.Infinity;
            foreach (IEnemy enemy in _enemyProvider.Enemies)
            {
                var enemyPos = enemy.EnemyObject.transform.position;
                var unitPos = unit.transform.position;
                float distanceToEnemy = Vector3.Distance(unitPos, enemyPos);

                if (distanceToEnemy < nearestDistance)
                {
                    nearestEnemyVector = enemyPos;
                    nearestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
            lastNearestEnemy = nearestEnemy;
            return nearestEnemyVector;
        }

    }
}
