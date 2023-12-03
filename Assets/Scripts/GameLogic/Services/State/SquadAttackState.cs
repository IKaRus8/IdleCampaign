using Data.Enums;
using GameLogic.Interfaces;
using UnityEngine;

namespace GameLogic.Services
{
    public class SquadAttackState : BaseState
    {
        private readonly SquadStateManager _squadStateManager;

        public SquadAttackState(SquadStateManager squadStateManager) : base(GameState.Attack)
        {
            _squadStateManager = squadStateManager;
        }
        public override void RunCurrentState()
        {

        }
    }
}
