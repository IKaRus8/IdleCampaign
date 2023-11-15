using GameLogic.Interfaces;
using UnityEngine;

namespace GameLogic.Services
{
    public class PlayerNormalState : PlayerBaseState
    {
        private float velocity;
        public PlayerNormalState(PlayerState playerState, float Velocity) : base(playerState, GameState.Normal)
        {
            velocity = Velocity;
        }
        public override void RunCurrentState(Rigidbody playerRigidbody, IPresenceOfEnemy presenceOfEnemy)
        {
            playerRigidbody.velocity = Vector3.forward * velocity;
        }
    }
}
