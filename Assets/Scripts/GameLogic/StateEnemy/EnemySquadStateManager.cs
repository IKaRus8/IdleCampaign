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
	public class EnemySquadStateManager
	{
		private IEnemySquadsProvider _enemySquadsProvider;
		private ISquadUnitsProvider _squadUnitsProvider;
		private IEnemyProvider _currentSquadEnemy;
		private EnemySquadBaseState _currentState;

		private Dictionary<GameState, EnemySquadBaseState> _allStates;

		private float _enemySquadAttackRadius;
		private float _enemySquadChaseRadius;
		private float _enemyUnitAttackRadius;

		public EnemySquadStateManager(IEnemySquadsProvider enemySquadsProvider, ISquadUnitsProvider squadUnitsProvider,
										float enemySquadAttackRadius, float enemySquadChaseRadius, float enemyUnitAttackRadius)
		{
			_enemySquadsProvider = enemySquadsProvider;
			_squadUnitsProvider = squadUnitsProvider;

			_enemySquadAttackRadius = enemySquadAttackRadius;
			_enemySquadChaseRadius = enemySquadChaseRadius;
			_enemyUnitAttackRadius = enemyUnitAttackRadius;

			_allStates = new Dictionary<GameState, EnemySquadBaseState>()
			{
				{GameState.Idle, new EnemySquadIdleState() },
				{GameState.Chase, new EnemySquadChaseState(enemySquadsProvider) },
				{GameState.Attack, new EnemySquadAttackState() }
			};
			_currentState = _allStates[GameState.Idle];
			if(_enemySquadsProvider.EnemySquads.Count==0)
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
			CheckPlayerUnits();
			_currentState.RunCurrentState();
		}

		private void CheckPlayerUnits()
		{
			if (CheckCurrentSquadEnemyNullable())
			{
				return;
			}
			var playerPosition = _squadUnitsProvider.SquadUnitsPosition;
			var enemyPosition = _enemySquadsProvider.EnemySquads[0].Enemies[0].EnemyPosition;
			var distance = Vector3.Distance(playerPosition, enemyPosition);
			switch (_currentState.GameState)
			{
				case GameState.Idle:
					CheckPlayerForIdleState(distance);
					break;
				case GameState.Chase:
					CheckPlayerForChaseState(distance);
					break;
				case GameState.Attack:
					CheckPlayerForAttackState(distance);
					break;
				default:
					break;
			}
		}
		private void CheckPlayerForIdleState(float distance)
		{
			if (distance > _enemySquadChaseRadius)
			{
				return;
			}
			SwitchState(GameState.Chase);
		}
		private void CheckPlayerForChaseState(float distance)
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

		private void CheckPlayerForAttackState(float distance)
		{
			if (distance < _enemySquadAttackRadius)
			{
				return;
			}
			SwitchState(GameState.Chase);
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
			if (_enemySquadsProvider.EnemySquads.Count() != 0)
			{
				_currentSquadEnemy = _enemySquadsProvider.EnemySquads[0];
				return false;
			}
			_currentSquadEnemy = null;
			return true;
		}
		private void SwitchState(GameState gameState)
		{
			if (_currentState.GameState != gameState)
			{
				_currentState = _allStates[gameState];
				ChangeEnemiesBehaviour();
			}
		}
		private void ChangeEnemiesBehaviour()
		{
			switch (_currentState.GameState)
			{
				case GameState.Idle:
					ChangeStateInIdle();
					break;
				case GameState.Chase:
					//
					break;
				case GameState.Attack:
					//
					break;
				default:
					break;
			}
		}

		private void ChangeStateInIdle()
		{

		}
	}
}
