using Data.Enums;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class UnitBaseState
    {
        public GameState GameState { get; }
        public UnitBaseState(GameState state)
        {
            GameState = state;
        }

        public abstract void RunCurrentState(IUnit unit);

    }
}
