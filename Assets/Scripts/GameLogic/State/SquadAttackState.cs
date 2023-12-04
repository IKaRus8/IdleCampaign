using Data.Enums;
using GameInfoModels.Interface;
using GameLogic.Interfaces;
using Models;
using Models.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace GameLogic.State
{
    public class SquadAttackState : BaseState
    {
        private readonly IEnemyProvider _enemyProvider;
        private readonly ISquadUnitsProvider _squadUnitsProvider;
        private readonly float _attackRadius;
        private readonly SquadStateManager _squadStateManager;
        private bool _isInAttackRange = false;
        private UnitStateManager _unitStateManager;
        public SquadAttackState(IEnemyProvider enemyProvider, ISquadUnitsProvider squadUnitsProvider, float attackRadius, SquadStateManager squadStateManager) : base(GameState.Attack)
        {
            _squadStateManager = squadStateManager;
            _enemyProvider = enemyProvider;
            _squadUnitsProvider = squadUnitsProvider;
            _attackRadius = attackRadius;
            _unitStateManager = new UnitStateManager();
        }
        public override void RunCurrentState()
        {
            foreach (var unit in _squadUnitsProvider.Units)
            {
                if (unit.UnitState == GameState.Attack && unit.TargetToPursue!=null)
                {
                    _unitStateManager.RunCurrentStateUnit(unit);
                    continue;
                }
                var unitNavMesh = unit.Agent;
                if (unitNavMesh.remainingDistance <= unitNavMesh.stoppingDistance && !unitNavMesh.pathPending)
                {
                    unit.UnitState = GameState.Attack;
                    continue;
                }
                var nearestEnemy = unit.TargetToPursue != null
                    ? unit.TargetToPursue
                    : FindNearestEnemy(unitNavMesh);

                if (nearestEnemy == null || nearestEnemy.EnemyPosition == Vector3.zero)
                {
                    unit.UnitState = GameState.Idle;
                    continue;
                }

                if (unitNavMesh.destination == nearestEnemy.EnemyPosition)
                {
                    continue;
                }
                unit.UnitState = GameState.Chase;

                //if (unitNavMesh.SetDestination(nearestEnemy.EnemyPosition))
                //{
                //    unitNavMesh.stoppingDistance = _attackRadius;
                //    unit.TargetToPursue = nearestEnemy;
                //}

                _unitStateManager.RunCurrentStateUnit(unit);
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
