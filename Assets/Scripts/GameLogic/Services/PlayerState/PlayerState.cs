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
            if (!_enemyProvider.isEnemyNotExist)
            {
                var enemyPositionZ = -_enemyProvider.Enemies[0].enemyPosition.z;
                var playerPositionZ = playerRigidbody.transform.localPosition.z;
                isEnemyInApproachRadius = (enemyPositionZ - playerPositionZ) < _approachRadius;
                return;
            }
            isEnemyInApproachRadius = false;
        }

        public bool SwitchState()
        {
            GameState gameState = isEnemyInApproachRadius ? GameState.Battle : GameState.Normal;

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
