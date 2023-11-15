using GameInfoModels;
using GameLogic.Controllers;
using GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace GameLogic.Services
{
    public class PlayerState : IDisposable
    {
        private readonly IPresenceOfEnemy _presenceOfEnemy;
        private readonly IDisposable _disposable;
        private PlayerBaseState _currentState;
        List<PlayerBaseState> _allStates;

        public PlayerState(float Velocity, IPresenceOfEnemy presenceOfEnemy)
        {
            _presenceOfEnemy = presenceOfEnemy;

            _allStates = new List<PlayerBaseState>()
            {
                new PlayerNormalState(this,Velocity),
                new PlayerBattleState(this,Velocity)
            };
            _disposable = presenceOfEnemy.EnemyOnScene.Subscribe(ChangeEnemyOnSceneBool);

            _currentState = _allStates.FirstOrDefault(state=>state._gameState==GameState.Normal);
        }
        public void Movement(Rigidbody playerRigidbody)
        {
            _currentState.RunCurrentState(playerRigidbody, _presenceOfEnemy);
        }
        public void SwitchState<T>() where T : PlayerBaseState
        {
            var currentState = _allStates.FirstOrDefault(s=>s is T);
            _currentState = currentState;
        }
        private void ChangeEnemyOnSceneBool(bool enemyOnScene)
        {
           if(_presenceOfEnemy.EnemyOnScene.Value)
            {
                SwitchState<PlayerBattleState>();
                return;
            }
            SwitchState<PlayerNormalState>();

        }
        public void Dispose()
        {
            _disposable?.Dispose();
        }

    }
}
