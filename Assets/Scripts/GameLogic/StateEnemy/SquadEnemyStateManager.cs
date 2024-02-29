using Data.Enums;
using GameInfoModels.Interfaces;
using GameLogic.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic.StateEnemy
{
	public class SquadEnemyStateManager
	{
		private IEnemySquadsProvider _enemySquadsProvider;
		private ISquadUnitsProvider _squadUnitsProvider;
		private IEnemyProvider _currentSquadEnemy;
		private SquadEnemyBaseState _currentState;

		private Dictionary<GameState, SquadEnemyBaseState> _allStates;

		private float _enemySquadAttackRadius;
		private float _enemySquadChaseRadius;

		public SquadEnemyStateManager(IEnemySquadsProvider enemySquadsProvider, ISquadUnitsProvider squadUnitsProvider,
										float enemySquadAttackRadius, float enemySquadChaseRadius, float enemyAttackRadius)
		{
			_enemySquadsProvider = enemySquadsProvider;
			_squadUnitsProvider = squadUnitsProvider;

			_enemySquadAttackRadius = enemySquadAttackRadius;
			_enemySquadChaseRadius = enemySquadChaseRadius;

			_allStates = new Dictionary<GameState, SquadEnemyBaseState>()
			{
				{GameState.Idle, new SquadEnemyIdleState() },
				{GameState.Chase, new SquadEnemyChaseState(enemySquadsProvider) },
				{GameState.Attack, new SquadEnemyAttackState(enemySquadsProvider,squadUnitsProvider,enemyAttackRadius,enemySquadAttackRadius) }
			};
			_currentState = _allStates[GameState.Idle];
			if (_enemySquadsProvider.EnemySquads.Count == 0)
			{
				_currentSquadEnemy = null;
			}
			else
			{
				_currentSquadEnemy = _enemySquadsProvider.EnemySquads[0];
			}
		}

		public void RunState()
		{
			CheckUnit();
			_currentState.RunState();
		}

		private void CheckUnit()
		{
			if (CheckCurrentSquadEnemyNullable())
			{
				SwitchState(GameState.Idle);
				return;
			}
			var UnitContainerPosition = _squadUnitsProvider.SquadUnitsPosition;
			var nearestEnemy = _enemySquadsProvider.EnemySquads[0].NearestEnemy;
			if (nearestEnemy == null)
			{
				SwitchState(GameState.Idle);
				return;
			}
			var enemyContainerPosition = nearestEnemy.EnemyPosition;
			var distance = Vector3.Distance(UnitContainerPosition, enemyContainerPosition);
			switch (_currentState.GameState)
			{
				case GameState.Idle:
					CheckUnitForIdleState(distance);
					break;
				case GameState.Chase:
					CheckUnitForChaseState(distance);
					break;
				case GameState.Attack:
					CheckUnitForAttackState(distance);
					break;
				default:
					break;
			}
		}
		private void CheckUnitForIdleState(float distance)
		{
			if (distance > _enemySquadChaseRadius)
			{
				return;
			}
			SwitchState(GameState.Chase);
		}
		private void CheckUnitForChaseState(float distance)
		{
			if (distance < _enemySquadAttackRadius)
			{
				SwitchState(GameState.Attack);
				return;
			}
			if (distance < _enemySquadChaseRadius)
			{
				return;
			}
			SwitchState(GameState.Idle);
		}

		private void CheckUnitForAttackState(float distance)
		{
			if (distance < _enemySquadAttackRadius)
			{
				return;
			}
			if (distance < _enemySquadChaseRadius)
			{
				SwitchState(GameState.Chase);
				return;
			}
			SwitchState(GameState.Idle);
		}

		private bool CheckCurrentSquadEnemyNullable()
		{
			if (_currentSquadEnemy == null)
			{
				return TryInitializeCurrentSquadEnemy();
			}
			if (!_currentSquadEnemy.IsEnemyNotExist)
			{
				return false;
			}
				_enemySquadsProvider.RemoveSquadEnemy(_currentSquadEnemy);
				return TryInitializeCurrentSquadEnemy();
		}
		private bool TryInitializeCurrentSquadEnemy()
		{
			var enemySquads = _enemySquadsProvider.EnemySquads;
			if (enemySquads.Count() == 0 || enemySquads[0].Enemies.Count == 0)
			{
				_currentSquadEnemy = null;
				return true;
			}
			_currentSquadEnemy = enemySquads[0];
			return false;
		}
		private void SwitchState(GameState gameState)
		{
			if (_currentState.GameState != gameState)
			{
				_currentState.ExitState();
				_currentState = _allStates[gameState];
				_currentState.EnterState();
			}
		}
	}
}
