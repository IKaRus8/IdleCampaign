using Data.Enums;
using GameInfoModels.Interface;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace GameLogic.Services
{
    public class PlayerStateManager
    {
        private readonly IEnemyProvider _enemyProvider;

        private PlayerBaseState _currentState;

        private List<PlayerBaseState> _allStates;

        private float _approachRadius;
        private bool isEnemyInApproachRadius;
        public PlayerStateManager(IEnemyProvider enemyProvider, float Velocity, float approachRadius)
        {
            _enemyProvider = enemyProvider;
            _approachRadius = approachRadius;

            _allStates = new List<PlayerBaseState>()
            {
                new PlayerNormalState(Velocity),
                new PlayerBattleState()
            };

            _currentState = _allStates.FirstOrDefault(state => state.GameState == GameState.Normal);
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
            if (!_enemyProvider.IsEnemyNotExist)
            {
                var enemyPosition = -_enemyProvider.Enemies[0].EnemyPosition;
                var playerPosition = playerRigidbody.transform.localPosition;
                isEnemyInApproachRadius = Vector3.Distance(enemyPosition,playerPosition) < _approachRadius;
                return;
            }
            isEnemyInApproachRadius = false;
        }

        public bool SwitchState()
        {
            GameState gameState = isEnemyInApproachRadius ? GameState.Battle : GameState.Normal;

            if (_currentState.GameState != gameState)
            {
                var currentState = _allStates.FirstOrDefault(s => s.GameState == gameState);
                _currentState = currentState;
                return true;
            }

            return false;
        }
        private void ChangePlayerBehaviour(Rigidbody playerRB)
        {
            switch (_currentState.GameState)
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
