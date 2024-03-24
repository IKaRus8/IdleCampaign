using Data.Enums;
using GameInfoModels.Interfaces;
using GameLogic.Interfaces;
using Models;
using UnityEngine;

namespace GameLogic.StateEnemy
{
	public class SquadEnemyAttackState : SquadEnemyBaseState
	{
		private readonly IEnemySquadsProvider _enemySquadsProvider;
		private readonly EnemyStateManager _enemyStateManager;
		public SquadEnemyAttackState(IEnemySquadsProvider enemySquadsProvider, ISquadUnitsProvider squadUnitsProvider, float attackRadius, float chaseRadius) : base(GameState.Attack)
		{
			_enemySquadsProvider = enemySquadsProvider;
			_enemyStateManager = new EnemyStateManager(squadUnitsProvider, attackRadius, chaseRadius);
		}

		public override void EnterState()
		{
			foreach (var enemy in _enemySquadsProvider.EnemySquads[0].Enemies)
			{
				var rb = enemy.Rigidbody;
				rb.velocity = Vector3.zero;
			}
		}
		public override void RunState()
		{
			foreach (var enemy in _enemySquadsProvider.EnemySquads[0].Enemies)
			{
				_enemyStateManager.EnemyState(enemy);
			}
		}
		public override void ExitState()
		{
			_enemySquadsProvider.EnemySquads[0].RemoveDeadEnemies();
		}

	}
}
