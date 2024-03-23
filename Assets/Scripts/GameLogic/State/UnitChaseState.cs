using Data.Enums;
using Models;
using Models.Interfaces;
using UnityEngine;

namespace GameLogic.State
{
	public class UnitChaseState : UnitBaseState
	{
		private float _distanceBetweenOpponents = 2f;

		public UnitChaseState() : base(GameState.Chase)
		{
		}

		public override void RunCurrentState(IUnit unit)
		{
			var unitNavMesh = unit.Agent;
			var targetToPursue = unit.TargetToPursue;

			if (unitNavMesh.destination == targetToPursue.EnemyPosition)
			{
				return;
			}
			var targetPosition = targetToPursue.EnemyPosition;

			Vector3 distance = targetPosition - unit.UnitPosition;
			Vector3 directionVectorFromUnitToTarget = distance.normalized;
			float offsetFromTargetCanter = targetToPursue.Agent.radius + _distanceBetweenOpponents;
			targetPosition -= directionVectorFromUnitToTarget * offsetFromTargetCanter;

			if (unitNavMesh.SetDestination(targetPosition))
			{
				return;
			}
			unit.TargetToPursue = null;

		}

	}
}
