using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;

namespace GameLogic.State
{
    public class UnitIdleState : UnitBaseState
    {
        public UnitIdleState() : base(GameState.Idle)
        {
        }


        public override void RunCurrentState(IUnit unit)
        {

        }
    }
}
