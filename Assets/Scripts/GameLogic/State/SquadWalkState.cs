using Data.Enums;
using GameInfoModels.Interfaces;
using Models;
using UnityEngine;

namespace GameLogic.State
{
    public class SquadWalkState : SquadUnitBaseState
	{
        private readonly Rigidbody _squadRigidbody;
        private readonly float _velocity;
        public SquadWalkState(float Velocity, Rigidbody squadRigidbody) : base(GameState.Walk)
        {
            _squadRigidbody = squadRigidbody;
            _velocity = Velocity;
        }
        public override void RunCurrentState()
        {
            _squadRigidbody.velocity = Vector3.forward * _velocity;
        }
    }
}
