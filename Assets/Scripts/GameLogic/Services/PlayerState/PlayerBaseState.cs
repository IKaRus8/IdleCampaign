using GameInfoModels;
using GameLogic.Controllers;
using GameLogic.Interfaces;
using UnityEngine;

namespace GameLogic.Services
{
    public abstract class PlayerBaseState
    {
        protected readonly PlayerState _stationMonobehavior;
        public GameState _gameState;
        public PlayerBaseState(PlayerState stationMonobehavior,GameState state)
        {
            _stationMonobehavior = stationMonobehavior;
            _gameState = state;
        }

        public abstract void RunCurrentState(Rigidbody playerRigidbody, bool enemyOnScene);
    }
}
