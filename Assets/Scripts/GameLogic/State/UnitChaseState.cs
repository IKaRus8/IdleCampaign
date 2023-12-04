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

            if (unitNavMesh.SetDestination(unit.TargetToPursue.EnemyPosition))
            {
                unitNavMesh.stoppingDistance = _attackRadius;
                unit.TargetToPursue = nearestEnemy;
            }

        }

    }
}
