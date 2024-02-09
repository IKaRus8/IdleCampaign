using Data.Enums;
using GameInfoModels.Interface;
using GameInfoModels.Interfaces;
using GameLogic.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.StateEnemy
{
	public class EnemySquadStateManager
	{
		private IEnemySquadsProvider _enemySquadsProvider;
		private ISquadUnitsProvider _squadUnitsProvider;

		private Dictionary<GameState, EnemySquadBaseState> _allStates;

		private BaseState _currentState;

		private IEnemyProvider _currentSquadEnemy;

		public EnemySquadStateManager(IEnemySquadsProvider enemySquadsProvider, ISquadUnitsProvider squadUnitsProvider)
		{
			_enemySquadsProvider = enemySquadsProvider;
			_squadUnitsProvider = squadUnitsProvider;

			_allStates = new Dictionary<GameState, EnemySquadBaseState>()
			{
				{GameState.Idle, new EnemySquadIdleState() },
				{GameState.Chase, new EnemySquadChaseState() },
				{GameState.Attack, new EnemySquadAttackState() }
			};
		}
		public void RunState()
		{

		}
	}
}
