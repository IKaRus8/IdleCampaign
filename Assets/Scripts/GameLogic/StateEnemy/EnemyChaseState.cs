using Data.Enums;
using log4net.Util;
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
			var targetPosition = enemy.TargetToPursue.UnitPosition;
			Vector3 targetBearing = targetPosition - enemy.EnemyPosition;
			float radius = enemyNavMesh.radius+2;
			targetPosition -= targetBearing.normalized * radius;
			if (enemyNavMesh.SetDestination(targetPosition))
			{
				return;
			}
			enemy.TargetToPursue = null;
		}
	}
}
