using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;
using Models;
using Models.Interfaces;
using UnityEngine;

namespace GameLogic.State
{
    public class UnitWalkState : UnitBaseState
    {
        public UnitWalkState() : base(GameState.Walk)
        {
        }

        public override void RunCurrentState(IUnit unit)
        {
            var unitNavMesh = unit.Agent;
            if(unitNavMesh.destination != Vector3.zero)
            if (unitNavMesh.SetDestination(unit.UnitPosition + new Vector3(0,0,10)))
            {
                unitNavMesh.isStopped = false;
            }
        }
    }
}
