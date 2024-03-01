using Data.Enums;
using Models;
using Models.Interfaces;
using UnityEngine;

namespace GameLogic.State
{
	public class UnitChaseState : UnitBaseState
	{
		public UnitChaseState() : base(GameState.Chase)
		{
		}

		public override void RunCurrentState(IUnit unit)
		{
			var unitNavMesh = unit.Agent;

			if (unitNavMesh.destination == unit.TargetToPursue.EnemyPosition)
			{
				return;
			}
			var targetPosition = unit.TargetToPursue.EnemyPosition;
			Vector3 targetBearing = targetPosition - unit.UnitPosition;
			float radius = unitNavMesh.radius + 2;
			targetPosition -= targetBearing.normalized * radius;

			if (unitNavMesh.SetDestination(targetPosition))
			{
				return;
			}
			unit.TargetToPursue = null;

		}

	}
}
