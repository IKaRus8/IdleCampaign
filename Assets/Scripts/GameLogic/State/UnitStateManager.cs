using Data.Enums;
using GameInfoModels.Interfaces;
using Models;
using Models.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GameLogic.State
{
    public class UnitStateManager
    {
        private readonly IEnemySquadsProvider _enemySquadsProvider;

        private readonly float _attackRadius;
        private readonly float _chaseRadius;

        private Dictionary<GameState, UnitBaseState> _allStates;

        public UnitStateManager(float unitAttackRadius, float chaseRadius, IEnemySquadsProvider enemySquadsProvider)
        {
            _enemySquadsProvider = enemySquadsProvider;
            _chaseRadius = chaseRadius;

            _allStates = new Dictionary<GameState, UnitBaseState>
            {
                {GameState.Idle, new UnitIdleState()},
                {GameState.Walk, new UnitWalkState()},
                {GameState.Chase, new UnitChaseState(unitAttackRadius)},
                {GameState.Attack, new UnitAttackState()}
            };
        }
        public void UnitState(IUnit unit)
        {
            switch (unit.UnitState)
            {
                case GameState.Idle:
                    CheckEnemyForIdleState(unit);
                    break;
                case GameState.Walk:
                    CheckEnemyForWalkState(unit);
                    break;
                case GameState.Chase:
                    CheckEnemyForChaseState(unit);
                    break;
                case GameState.Attack:
                    CheckEnemyForAttackState(unit);
                    break;
                default:
                    break;
            }
            RunCurrentStateUnit(unit);
        }
        private void RunCurrentStateUnit(IUnit unit)
        {
            _allStates[unit.UnitState].RunCurrentState(unit);
        }

        private void CheckEnemyForIdleState(IUnit unit)
        {
            unit.UnitState = GameState.Walk;
        }
        private void CheckEnemyForWalkState(IUnit unit)
        {
            var unitNavMesh = unit.Agent;
            var nearestEnemy = FindNearestEnemy(unitNavMesh);
            if (nearestEnemy == null || nearestEnemy.EnemyPosition == Vector3.zero)
            {
                return;
            }
            unit.UnitState = GameState.Chase;
            unit.TargetToPursue = nearestEnemy;

        }
        private void CheckEnemyForChaseState(IUnit unit)
        {
            var unitNavMesh = unit.Agent;
            if (unit.TargetToPursue != null)
            {
                    if (unitNavMesh.destination != unit.TargetToPursue.EnemyPosition)
                    {
                        return;
                    }

                    if (unitNavMesh.remainingDistance <= unitNavMesh.stoppingDistance && !unitNavMesh.pathPending)
                    {
                        unit.UnitState = GameState.Attack;
                        return;
                    }
            }
            unitNavMesh.isStopped = true;
            unit.UnitState = GameState.Walk;
        }
        private void CheckEnemyForAttackState(IUnit unit)
        {
            if (unit.TargetToPursue != null)
            {
                if (Vector3.Distance(unit.TargetToPursue.EnemyPosition, unit.UnitPosition) > _attackRadius)
                {
                    unit.UnitState = GameState.Chase;
                }
                return;
            }
            unit.UnitState = GameState.Idle;

        }

        private IEnemy FindNearestEnemy(NavMeshAgent unit)
        {
            IEnemy nearestEnemy = null;
            float nearestDistance = Mathf.Infinity;
            var unitPos = unit.transform.position;

            foreach (IEnemy enemy in _enemySquadsProvider.EnemySquads[0].Enemies)
            {
                if(enemy.IsDead)
                {
                    continue;
                }
                var enemyPos = enemy.EnemyPosition;
                float distanceToEnemy = Vector3.Distance(unitPos, enemyPos);
                if (distanceToEnemy > _chaseRadius)
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
