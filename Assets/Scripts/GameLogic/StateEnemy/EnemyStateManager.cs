using Data.Enums;
using GameLogic.Interfaces;
using Models;
using Models.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GameLogic.StateEnemy
{
	internal class EnemyStateManager
	{
		private readonly ISquadUnitsProvider _squadUnitsProvider;

		private readonly float _attackRadius;
		private readonly float _chaseRadius;

		private Dictionary<GameState, EnemyBaseState> _allStates;

		public EnemyStateManager(ISquadUnitsProvider squadUnitsProvider, float attackRadius, float chaseRadius)
		{
			_squadUnitsProvider = squadUnitsProvider;
			_attackRadius = attackRadius;
			_chaseRadius = chaseRadius;

			_allStates = new Dictionary<GameState, EnemyBaseState>
			{
				{GameState.Idle, new EnemyIdleState()},
				{GameState.Walk, new EnemyWalkState()},
				{GameState.Chase, new EnemyChaseState()},
				{GameState.Attack, new EnemyAttackState()}
			};
		}
		public void EnemyState(IEnemy enemy)
		{
			switch (enemy.EnemyState)
			{
				case GameState.Idle:
					CheckUnitForIdleState(enemy);
					break;
				case GameState.Walk:
					CheckUnitForWalkState(enemy);
					break;
				case GameState.Chase:
					CheckUnitForChaseState(enemy);
					break;
				case GameState.Attack:
					CheckUnitForAttackState(enemy);
					break;
				default:
					break;
			}
			RunCurrentStateEnemy(enemy);
		}
		private void RunCurrentStateEnemy(IEnemy enemy)
		{
			_allStates[enemy.EnemyState].RunCurrentState(enemy);
		}
		private void CheckUnitForIdleState(IEnemy enemy)
		{
			enemy.EnemyState = GameState.Walk;
		}
		private void CheckUnitForWalkState(IEnemy enemy)
		{
			var enemyNavMesh = enemy.Agent;
			var nearestUnit = FindNearestUnit(enemyNavMesh);
			if (nearestUnit == null || nearestUnit.UnitPosition == Vector3.zero)
			{
				return;
			}
			enemy.EnemyState = GameState.Chase;
			ChangeStateInChase(enemy);
			enemy.TargetToPursue = nearestUnit;

		}
		private void CheckUnitForChaseState(IEnemy enemy)
		{
			var enemyNavMesh = enemy.Agent;
			if (enemy.TargetToPursue != null)
			{
				if (Vector3.Distance(enemy.EnemyPosition, enemy.TargetToPursue.UnitPosition) < _attackRadius)
				{
					enemy.EnemyState = GameState.Attack;
					ChangeStateInAttack(enemy);
					return;
				}
				return;
			}
			enemy.EnemyState = GameState.Walk;
			ChangeStateInWalk(enemy);
		}
		private void CheckUnitForAttackState(IEnemy enemy)
		{
			if (enemy.TargetToPursue != null)
			{
				if (Vector3.Distance(enemy.TargetToPursue.UnitPosition, enemy.EnemyPosition) > _attackRadius)
				{
					enemy.EnemyState = GameState.Chase;
					ChangeStateInChase(enemy);
				}
				return;
			}
			enemy.EnemyState = GameState.Idle;
		}

		private IUnit FindNearestUnit(NavMeshAgent enemyAgent)
		{
			IUnit nearestUnit = null;
			float nearestDistance = Mathf.Infinity;
			var enemyPos = enemyAgent.transform.position;

			foreach (IUnit unit in _squadUnitsProvider.Units)
			{
				if (unit.IsDead)
				{
					continue;
				}
				var unitPos = unit.UnitPosition;
				float distanceToUnit = Vector3.Distance(unitPos, enemyPos);
				if (distanceToUnit > _chaseRadius)
				{
					continue;
				}
				if (distanceToUnit < nearestDistance)
				{
					nearestDistance = distanceToUnit;
					nearestUnit = unit;
				}
			}
			return nearestUnit;
		}

		private void ChangeStateInWalk(IEnemy enemy)
		{
			enemy.Agent.isStopped = true;
		}
		private void ChangeStateInChase(IEnemy enemy)
		{
			enemy.Rigidbody.velocity = Vector3.zero;
		}
		private void ChangeStateInAttack(IEnemy enemy)
		{
			enemy.Agent.isStopped = true;

		}
	}
}
