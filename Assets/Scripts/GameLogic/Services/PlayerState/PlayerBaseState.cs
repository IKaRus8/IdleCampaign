using Data.Enums;
using GameLogic.Interfaces;
using UnityEngine;

namespace GameLogic.Services
{
    public abstract class PlayerBaseState
    {
        public GameState GameState { get; }
        public PlayerBaseState( GameState state)
        {
            GameState = state;
        }

        public abstract void RunCurrentState();
    }
}
