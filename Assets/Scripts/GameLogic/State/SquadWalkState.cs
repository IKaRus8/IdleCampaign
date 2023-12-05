using Data.Enums;
using GameInfoModels.Interface;
using Models;
using UnityEngine;

namespace GameLogic.State
{
    public class SquadWalkState : BaseState
    {
        private readonly Rigidbody _squadRigidbody;
        private readonly float velocity;
        public SquadWalkState(float Velocity, Rigidbody squadRigidbody) : base(GameState.Walk)
        {
            _squadRigidbody = squadRigidbody;
            velocity = Velocity;
        }
        public override void RunCurrentState()
        {
            _squadRigidbody.velocity = Vector3.forward * velocity;
        }
    }
}
