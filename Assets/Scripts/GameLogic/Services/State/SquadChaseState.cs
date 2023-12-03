using GameLogic.Interfaces;
using Data.Enums;
using GameInfoModels.Interface;
using Models.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace GameLogic.Services
{
    public class SquadChaseState : BaseState
    {
        private readonly IEnemyProvider _enemyProvider;
        private readonly ISquadProvider _playerProvider;
        private readonly float _attackRadius;
        private readonly SquadStateManager _squadStateManager;
        private bool _isInAttackRange = false;
        public SquadChaseState(IEnemyProvider enemyProvider, ISquadProvider playerProvider, float attackRadius, SquadStateManager squadStateManager) : base(GameState.Chase)
        {
            _squadStateManager = squadStateManager;
            _enemyProvider = enemyProvider;
            _playerProvider = playerProvider;
            _attackRadius = attackRadius;
        }
        public override void RunCurrentState()
        {
            if (_isInAttackRange)
            {
                _squadStateManager.SwitchState(GameState.Attack);
                return;
            }

            foreach (var unit in _playerProvider.Units)
            {
                var unitNavMesh = unit.Agent;
                var nearestEnemy = unit.TargetToPursue != null
                    ? unit.TargetToPursue
                    : FindNearestEnemy(unitNavMesh);

                if (nearestEnemy == null || nearestEnemy.EnemyPosition == Vector3.zero)
                {
                    continue;
                }

                if (unitNavMesh.destination == nearestEnemy.EnemyPosition)
                {
                    continue;
                }

                if (unitNavMesh.SetDestination(nearestEnemy.EnemyPosition))
                {
                    unitNavMesh.stoppingDistance = _attackRadius;
                    unit.TargetToPursue = nearestEnemy;
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
