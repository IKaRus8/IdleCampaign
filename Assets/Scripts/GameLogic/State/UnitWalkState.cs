using Data.Enums;
using Models;
using Models.Interfaces;
using UnityEngine;

namespace GameLogic.State
{
    public class UnitWalkState : UnitBaseState
    {
        private Vector3 _vectorMoveForward = Vector3.forward * 10f;
        public UnitWalkState() : base(GameState.Walk)
        {
        }

        public override void RunCurrentState(IUnit unit)
        {
            var unitNavMesh = unit.Agent;
            if (unitNavMesh.destination != Vector3.zero)
                if (unitNavMesh.SetDestination(unit.UnitPosition + _vectorMoveForward))
                {
                    unitNavMesh.isStopped = false;
                }
        }
    }
}
