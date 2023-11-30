using Data.Enums;
using GameInfoModels.Interface;
using GameLogic.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace GameLogic.Services
{
    public class PlayerStateManager
    {
        private readonly IEnemyProvider _enemyProvider;
        private readonly IPlayerProvider _playerProvider;

        private PlayerBaseState _currentState;

        private List<PlayerBaseState> _allStates;

        private Rigidbody _rigidbody;
        private float _approachRadius;
        private bool isEnemyInApproachRadius;
        public PlayerStateManager(IEnemyProvider enemyProvider, IPlayerProvider playerProvider, Rigidbody rigidbody,
                                    float velocity, float approachRadius, float attackRadius)
        {
            _enemyProvider = enemyProvider;
            _playerProvider = playerProvider;
            _rigidbody = rigidbody;
            _approachRadius = approachRadius;

            _allStates = new List<PlayerBaseState>()
            {
                new PlayerNormalState(velocity, rigidbody),
                new PLayerChaseState(enemyProvider,playerProvider,attackRadius),
                new PlayerBattleState()
            };

            _currentState = _allStates.FirstOrDefault(state => state.GameState == GameState.Normal);
        }
        public void Movement()
        {
            if (_playerProvider.Units.Count == 0)
            {
                return;
            }
            CheckEnemyNearby();
            SwitchState();

            _currentState.RunCurrentState();
        }
        private void CheckEnemyNearby()
        {
            if (!_enemyProvider.IsEnemyNotExist)
            {
                var enemyPosition = _enemyProvider.Enemies[0].EnemyPosition;
                var playerPosition = _rigidbody.transform.position;
                var distance = Vector3.Distance(enemyPosition, playerPosition);
                isEnemyInApproachRadius = distance < _approachRadius;
                return;
            }
            isEnemyInApproachRadius = false;
        }

        public void SwitchState()
        {
            GameState gameState = isEnemyInApproachRadius ? GameState.Chase : GameState.Normal;

            if (_currentState.GameState != gameState)
            {
                var currentState = _allStates.FirstOrDefault(s => s.GameState == gameState);
                _currentState = currentState;

                ChangePlayerBehaviour();
            }
        }
        private void ChangePlayerBehaviour()
        {
            switch (_currentState.GameState)
            {
                case GameState.Normal:
                    _playerProvider.Units[0].PlayerObject.transform.localPosition = Vector3.zero;
                    break;
                case GameState.Chase:
                    _rigidbody.velocity = Vector3.forward;
                    break;
                default:
                    break;
            }
        }
    }
}
