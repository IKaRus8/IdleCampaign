using Data.Enums;
using GameInfoModels.Interfaces;
using GameLogic.Interfaces;
using Models;
using System.Collections.Generic;
using System.Linq;

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
				{GameState.Chase, new EnemySquadChaseState() },
				{GameState.Attack, new EnemySquadAttackState() }
			};
			_currentState = _allStates[GameState.Idle];
			_currentSquadEnemy = _enemySquadsProvider.EnemySquads[0];
		}

		public void RunState()
		{
			CheckPlayerUnits();
			_currentState.RunCurrentState();
		}

		private void CheckPlayerUnits()
		{
			if(!CheckCurrentSquadEnemyNullable())
			{

			}

		}
		private bool CheckCurrentSquadEnemyNullable()
		{
			if(_currentSquadEnemy == null)
			{
				return TryInitializeCurrentSquadEnemy();
			}
			if (!_currentSquadEnemy.IsEnemyNotExist)
			{
				return true;
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
	}
}
