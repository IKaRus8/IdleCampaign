using Data.Enums;
using GameLogic.Interfaces;
using UnityEngine;

namespace GameLogic.Services
{
    public class PlayerBattleState : PlayerBaseState
    {
        public PlayerBattleState(PlayerState playerState) : base(playerState, GameState.Battle)
        {
        }
        public override void RunCurrentState(Rigidbody playerRigidbody)
        {
        }
    }
}
