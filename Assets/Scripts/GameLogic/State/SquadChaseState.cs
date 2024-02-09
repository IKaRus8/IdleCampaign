using Data.Enums;
using GameInfoModels.Interfaces;
using Models;
using UnityEngine;

namespace GameLogic.State
{
    public class SquadChaseState : BaseState
    {
        private const float speedChase = 3f;
        private readonly Rigidbody _squadRigidbody;
        private readonly float _velocity;
        public SquadChaseState(float Velocity, Rigidbody squadRigidbody) : base(GameState.Chase)
        {
            _velocity = Velocity;
            _squadRigidbody = squadRigidbody;
        }
        public override void RunCurrentState()
        {
                _squadRigidbody.velocity = Vector3.forward * (_velocity + speedChase);
        }
    }
}
