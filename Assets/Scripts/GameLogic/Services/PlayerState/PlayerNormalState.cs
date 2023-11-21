using Data.Enums;
using GameLogic.Interfaces;
using UnityEngine;

namespace GameLogic.Services
{
    public class PlayerNormalState : PlayerBaseState
    {
        private float velocity;
        public PlayerNormalState(float Velocity) : base(GameState.Normal)
        {
            velocity = Velocity;
        }
        public override void RunCurrentState(Rigidbody playerRigidbody)
        {
            playerRigidbody.velocity = Vector3.forward * velocity;
        }
    }
}
