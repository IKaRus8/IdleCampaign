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
			RunStateEnemy(enemy);
		}
		private void RunStateEnemy(IEnemy enemy)
		{
			_allStates[enemy.EnemyState].RunState(enemy);
		}
		private void CheckUnitForIdleState(IEnemy enemy)
		{
			SwitchState(enemy, GameState.Walk);
		}
		private void CheckUnitForWalkState(IEnemy enemy)
		{
			var enemyNavMesh = enemy.Agent;
			var nearestUnit = FindNearestUnit(enemyNavMesh);
			if (nearestUnit == null || nearestUnit.UnitPosition == Vector3.zero)
			{
				return;
			}
			EnterChaseState(enemy);
			SwitchState(enemy, GameState.Chase);
			enemy.TargetToPursue = nearestUnit;
		}
		private void CheckUnitForChaseState(IEnemy enemy)
		{
			if (enemy.TargetToPursue != null)
			{
				var distance = Vector3.Distance(enemy.EnemyPosition, enemy.TargetToPursue.UnitPosition);
				if (distance < _attackRadius)
				{
					ExitFromChaseState(enemy);
					SwitchState(enemy, GameState.Attack);
					return;
				}
				return;
			}
			ExitFromChaseState(enemy);
			SwitchState(enemy, GameState.Walk);
		}
		private void CheckUnitForAttackState(IEnemy enemy)
		{
			if (enemy.TargetToPursue != null)
			{
				var distance = Vector3.Distance(enemy.TargetToPursue.UnitPosition, enemy.EnemyPosition);
				if (distance > _attackRadius)
				{
					EnterChaseState(enemy);
					SwitchState(enemy, GameState.Chase);
				}
				return;
			}
			SwitchState(enemy, GameState.Idle);
		}
		private void SwitchState(IEnemy enemy, GameState state)
		{
			if (enemy.EnemyState == state)
			{
				return;
			}
			_allStates[enemy.EnemyState].ExitState();
			enemy.EnemyState = state;
			_allStates[enemy.EnemyState].EnterState();
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
		private void ExitFromChaseState(IEnemy enemy)
		{
			enemy.Agent.isStopped = true;
		}
		private void EnterChaseState(IEnemy enemy)
		{
			enemy.Rigidbody.velocity = Vector3.zero;
		}
	}
}
