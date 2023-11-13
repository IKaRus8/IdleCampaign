using GameInfoModels;
using GameLogic.Controllers;
using GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic.Services
{
    public class PlayerState
    {
        private PlayerBaseState _currentState;
        List<PlayerBaseState> _allStates;
        bool enemyOnScene;
        public PlayerState(float Velocity)
        {
            _allStates = new List<PlayerBaseState>()
            {
                new PlayerNormalState(this,Velocity),
                new PlayerBattleState(this)
            };
            _currentState = _allStates.FirstOrDefault(state=>state._gameState==GameState.Normal);
        }
        public void Movement(Rigidbody playerRigidbody)
        {
            _currentState.RunCurrentState(playerRigidbody, enemyOnScene);
        }
        public void SwitchState<T>() where T : PlayerBaseState
        {
            var currentState = _allStates.FirstOrDefault(s=>s is T);
            _currentState = currentState;
        }
    }
}
