using Data.Enums;
using GameInfoModels.Interface;
using Models;
using Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace GameLogic.State
{
    public class UnitStateManager
    {
        private readonly IEnemyProvider _enemyProvider;

        private readonly float _attackRadius;
        private readonly float _chaseRadius;

        private Dictionary<GameState, UnitBaseState> _allStates;

        public UnitStateManager(float unitAttackRadius, float chaseRadius, IEnemyProvider enemyProvider)
        {
            _enemyProvider = enemyProvider;
            _chaseRadius = chaseRadius;
            _allStates = new Dictionary<GameState, UnitBaseState>
            {
                {GameState.Walk, new UnitWalkState()},
                {GameState.Chase, new UnitChaseState(unitAttackRadius)},
                {GameState.Attack, new UnitAttackState()}
            };
        }
        public void RunCurrentStateUnit(IUnit unit)
        {
            _allStates[unit.UnitState].RunCurrentState(unit);
        }

        public void UnitState(IUnit unit)
        {
            var unitNavMesh = unit.Agent;
            if (unit.TargetToPursue != null)
            {
                if (unit.UnitState == GameState.Attack)
                {
                    if (Vector3.Distance(unit.TargetToPursue.EnemyPosition, unit.UnitPosition) > _attackRadius)
                    {
                        unit.UnitState = GameState.Chase;
                    }
                    RunCurrentStateUnit(unit);
                    return;
                }

                if (unitNavMesh.destination != Vector3.zero)
                {
                    if (unitNavMesh.remainingDistance <= unitNavMesh.stoppingDistance && !unitNavMesh.pathPending)
                    {
                        unit.UnitState = GameState.Attack;
                        RunCurrentStateUnit(unit);
                        return;
                    }
                }
                if (unitNavMesh.destination == unit.TargetToPursue.EnemyPosition)
                {
                    return;
                }
            }
            unitNavMesh.isStopped = true;

            var nearestEnemy = FindNearestEnemy(unitNavMesh);

            if (nearestEnemy == null || nearestEnemy.EnemyPosition == Vector3.zero)
            {
                unit.UnitState = GameState.Walk;
                RunCurrentStateUnit(unit);
                return;
            }
            
            unit.UnitState = GameState.Chase;
            unit.TargetToPursue = nearestEnemy;

            RunCurrentStateUnit(unit);
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
                if(distanceToEnemy > _chaseRadius)
                {
                    continue;
                }
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
