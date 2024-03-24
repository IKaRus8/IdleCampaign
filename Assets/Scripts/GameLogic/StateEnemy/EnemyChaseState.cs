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
		private float _distanceBetweenOpponents = 2f;
		public EnemyChaseState() : base(GameState.Chase)
		{
		}

		public override void RunState(IEnemy enemy)
		{
			var enemyNavMesh = enemy.Agent;
			var targetToPursue = enemy.TargetToPursue;

			if (enemyNavMesh.destination == targetToPursue.UnitPosition)
			{
				return;
			}
			var targetPosition = targetToPursue.UnitPosition;

			Vector3 distance = targetPosition - enemy.EnemyPosition;
			Vector3 directionVectorFromUnitToTarget = distance.normalized;
			float offsetFromTargetCanter = targetToPursue.Agent.radius + _distanceBetweenOpponents;
			targetPosition -= directionVectorFromUnitToTarget * offsetFromTargetCanter;


			if (enemyNavMesh.SetDestination(targetPosition))
			{
				return;
			}
			enemy.TargetToPursue = null;
		}
	}
}
