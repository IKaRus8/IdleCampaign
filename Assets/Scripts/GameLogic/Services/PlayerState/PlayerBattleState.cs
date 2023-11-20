using Data.Enums;
using GameLogic.Interfaces;
using UnityEngine;

namespace GameLogic.Services
{
    public class PlayerBattleState : PlayerBaseState
    {
        public PlayerBattleState() : base(GameState.Battle)
        {
        }
        public override void RunCurrentState(Rigidbody playerRigidbody)
        {
        }
    }
}
