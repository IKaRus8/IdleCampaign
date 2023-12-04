using Data.Enums;
using GameLogic.State.Interfaces;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.State
{
    public class UnitStateManager : IUnitStateManager
    {
        private Dictionary<GameState, UnitBaseState> _allStates;

        public UnitStateManager()
        {
            _allStates = new Dictionary<GameState, UnitBaseState>
            {
                {GameState.Idle, new UnitIdleState()},
                {GameState.Chase, new UnitChaseState()},
                {GameState.Attack, new UnitAttackState()}
            };
        }
        public void RunCurrentStateUnit(IUnit unit)
        {
            _allStates[unit.UnitState].RunCurrentState(unit);
        }
    }
}
