using Data.Enums;
using UnityEngine;

namespace GameLogic.Services
{
    public class PlayerNormalState : PlayerBaseState
    {
        private Rigidbody _playerRigidbody;
        private float velocity;
        public PlayerNormalState(float Velocity, Rigidbody playerRigidbody) : base(GameState.Normal)
        {
            _playerRigidbody = playerRigidbody;
            velocity = Velocity;
        }
        public override void RunCurrentState()
        {
             _playerRigidbody.velocity = Vector3.forward * velocity;
        }
    }
}
