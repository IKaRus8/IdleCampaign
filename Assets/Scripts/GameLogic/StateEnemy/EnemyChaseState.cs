using Data.Enums;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace GameLogic.StateEnemy
{
	internal class EnemyChaseState : EnemyBaseState
	{
		public EnemyChaseState() : base(GameState.Chase)
		{
		}

		public override void RunState(IEnemy enemy)
		{
			var enemyNavMesh = enemy.Agent;

			if (enemyNavMesh.destination == enemy.TargetToPursue.UnitPosition)
			{
				return;
			}

			if (enemyNavMesh.SetDestination(enemy.TargetToPursue.UnitPosition))
			{
				return;
			}
			enemy.TargetToPursue = null;
		}
	}
}
