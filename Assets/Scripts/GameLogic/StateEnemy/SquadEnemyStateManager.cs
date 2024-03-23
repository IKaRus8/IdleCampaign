using Data.Enums;
using GameInfoModels.Interfaces;
using GameLogic.Interfaces;
using Models;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace GameLogic.StateEnemy
{
	public class SquadEnemyStateManager : ISquadEnemyStateManager
	{
		private IEnemySquadsProvider _enemySquadsProvider;
		private ISquadUnitsProvider _squadUnitsProvider;
		private IEnemyOptions _enemyOptions;
		private IEnemyProvider _currentSquadEnemy;

		private SquadEnemyBaseState _currentState;
		private Dictionary<GameState, SquadEnemyBaseState> _allStates;

		public SquadEnemyStateManager(IEnemyOptions enemyOptions,IEnemySquadsProvider enemySquadsProvider, ISquadUnitsProvider squadUnitsProvider)
		{
			_enemySquadsProvider = enemySquadsProvider;
			_squadUnitsProvider = squadUnitsProvider;
			_enemyOptions = enemyOptions;

			_allStates = new Dictionary<GameState, SquadEnemyBaseState>()
			{
				{GameState.Idle, new SquadEnemyIdleState() },
				{GameState.Chase, new SquadEnemyChaseState(enemySquadsProvider) },
				{GameState.Attack, new SquadEnemyAttackState(enemySquadsProvider,squadUnitsProvider,enemyOptions.EnemyAttackRadius,enemyOptions.EnemySquadAttackRadius) }
			};
			_currentState = _allStates[GameState.Idle];

			_currentSquadEnemy = null;
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
			var nearestUnit = _squadUnitsProvider.NearestUnitToEnemyZAxis;
			var nearestEnemy = _enemySquadsProvider.EnemySquads[0].NearestEnemyToUnitZAxis;

			if (nearestEnemy == null || nearestUnit == null)
			{
				SwitchState(GameState.Idle);
				return;
			}
			var UnitContainerPosition = nearestUnit.UnitPosition;
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
			if (distance > _enemyOptions.EnemySquadChaseRadius)
			{
				return;
			}
			SwitchState(GameState.Chase);
		}
		private void CheckUnitForChaseState(float distance)
		{
			if (distance < _enemyOptions.EnemySquadAttackRadius)
			{
				SwitchState(GameState.Attack);
				return;
			}
			if (distance < _enemyOptions.EnemySquadChaseRadius)
			{
				return;
			}
			SwitchState(GameState.Idle);
		}

		private void CheckUnitForAttackState(float distance)
		{
			if (distance < _enemyOptions.EnemySquadAttackRadius)
			{
				return;
			}
			if (distance < _enemyOptions.EnemySquadChaseRadius)
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
