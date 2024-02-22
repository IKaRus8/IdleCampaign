using Data.Enums;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.StateEnemy
{
	internal class EnemyChaseState : EnemyBaseState
	{
		private float _attackRadius;
		public EnemyChaseState(float attackRadius) : base(GameState.Chase)
		{
			_attackRadius = attackRadius;
		}

		public override void RunCurrentState(IEnemy enemy)
		{
			var enemyNavMesh = enemy.Agent;

			if (enemyNavMesh.destination == enemy.TargetToPursue.UnitPosition)
			{
				return;
			}

			if (enemyNavMesh.SetDestination(enemy.TargetToPursue.UnitPosition))
			{
				enemyNavMesh.isStopped = false;
				enemyNavMesh.stoppingDistance = _attackRadius;
				return;
			}
			enemy.TargetToPursue = null;
		}

	}
}
