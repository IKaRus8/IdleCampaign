using Data.Enums;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.State
{
    public class UnitAttackState : UnitBaseState
    {
        public UnitAttackState() : base(GameState.Attack)
        {
        }

        public override void RunCurrentState(IUnit unit)
        {

        }
    }
}
