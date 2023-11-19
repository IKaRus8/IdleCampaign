using Data.Enums;
using GameInfoModels.Interface;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace GameLogic.Services
{
    public class PlayerState
    {
        private readonly IEnemyProvider _enemyProvider;

        private PlayerBaseState _currentState;

        List<PlayerBaseState> _allStates;

        private float _approachRadius;
        private bool isEnemyNotExist => _enemyProvider.Enemies.Count == 0;
        private bool isEnemyInApproachRadius;
        public PlayerState(IEnemyProvider enemyProvider, float Velocity, float approachRadius)
        {
            _enemyProvider = enemyProvider;
            _approachRadius = approachRadius;

            _allStates = new List<PlayerBaseState>()
            {
                new PlayerNormalState(this,Velocity),
                new PlayerBattleState(this)
            };

            _currentState = _allStates.FirstOrDefault(state => state._gameState == GameState.Normal);
        }
        public void Movement(Rigidbody playerRigidbody)
        {
            CheckEnemyNearby(playerRigidbody);

            var isStateChanged = SwitchState();
            if(isStateChanged)
                ChangePlayerBehaviour(playerRigidbody);

            _currentState.RunCurrentState(playerRigidbody);
        }
        private void CheckEnemyNearby(Rigidbody playerRigidbody)
        {
            if (!isEnemyNotExist)
            {
                var enemyPositionZ = -_enemyProvider.Enemies[0].enemyObject.transform.localPosition.z;
                isEnemyInApproachRadius = (enemyPositionZ - playerRigidbody.transform.localPosition.z) < _approachRadius;
            }
        }

        public bool SwitchState()
        {
            GameState gameState = GameState.Normal;
            if (isEnemyNotExist)
            {
                gameState = GameState.Normal;
            }
            else if(isEnemyInApproachRadius)
            {
                gameState = GameState.Battle;
            }

            if (_currentState._gameState != gameState)
            {
                var currentState = _allStates.FirstOrDefault(s => s._gameState == gameState);
                _currentState = currentState;
                return true;
            }

            return false;
        }
        private void ChangePlayerBehaviour(Rigidbody playerRB)
        {
            switch (_currentState._gameState)
            {
                case GameState.Battle:
                    playerRB.velocity = Vector3.forward;
                    break;
                default:
                    break;
            }
        }
    }
}
