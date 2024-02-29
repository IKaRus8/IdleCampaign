using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;
using Models;
using Models.Interfaces;

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

            if (unitNavMesh.SetDestination(unit.TargetToPursue.EnemyPosition))
            {
                return;
            }
            unit.TargetToPursue = null;

        }

    }
}
