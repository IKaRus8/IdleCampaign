using Data.Enums;
using GameInfoModels.Interfaces;
using GameLogic.Interfaces;
using GameLogic.State;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.AI;
using UnityEngine;

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
				{GameState.Chase, new EnemyChaseState(attackRadius)},
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
			enemy.TargetToPursue = nearestUnit;

		}
		private void CheckUnitForChaseState(IEnemy enemy)
		{
			var enemyNavMesh = enemy.Agent;
			if (enemy.TargetToPursue != null)
			{
				if (enemyNavMesh.destination != enemy.TargetToPursue.UnitPosition)
				{
					return;
				}

				if (enemyNavMesh.remainingDistance <= enemyNavMesh.stoppingDistance && !enemyNavMesh.pathPending)
				{
					enemy.EnemyState = GameState.Attack;
					return;
				}
			}
			enemyNavMesh.isStopped = true;
			enemy.EnemyState = GameState.Walk;
		}
		private void CheckUnitForAttackState(IEnemy enemy)
		{
			if (enemy.TargetToPursue != null)
			{
				if (Vector3.Distance(enemy.TargetToPursue.UnitPosition, enemy.EnemyPosition) > _attackRadius)
				{
					enemy.EnemyState = GameState.Chase;
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

	}
}
