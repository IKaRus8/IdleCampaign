using Data.Enums;
using GameLogic.Interfaces;
using UnityEngine;

namespace GameLogic.Services
{
    public abstract class PlayerBaseState
    {
        protected readonly PlayerState _playerState;
        public GameState _gameState { get; }
        public PlayerBaseState(PlayerState playerState, GameState state)
        {
            _playerState = playerState;
            _gameState = state;
        }

        public abstract void RunCurrentState(Rigidbody playerRigidbody);
    }
}
