using Data.Enums;
using GameLogic.Interfaces;
using UnityEngine;

namespace GameLogic.Services
{
    public abstract class BaseState
    {
        public GameState GameState { get; }
        public BaseState( GameState state)
        {
            GameState = state;
        }

        public abstract void RunCurrentState();
    }
}
