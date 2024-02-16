using Data.Enums;
using GameInfoModels.Interfaces;
using GameLogic.Interfaces;
using Models;

namespace GameLogic.StateEnemy
{
	public class EnemySquadAttackState : EnemySquadBaseState
	{
		private readonly IEnemySquadsProvider _enemySquadsProvider;
		private readonly EnemyStateManager _enemyStateManager;
		public EnemySquadAttackState(IEnemySquadsProvider enemySquadsProvider, ISquadUnitsProvider squadUnitsProvider, float attackRadius, float chaseRadius) : base(GameState.Attack)
		{
			_enemySquadsProvider = enemySquadsProvider;
			_enemyStateManager = new EnemyStateManager(squadUnitsProvider, attackRadius, chaseRadius);
		}

		public override void RunCurrentState()
		{
			foreach (var enemy in _enemySquadsProvider.EnemySquads[0].Enemies)
			{
				_enemyStateManager.EnemyState(enemy);
			}
		}
	}
}
