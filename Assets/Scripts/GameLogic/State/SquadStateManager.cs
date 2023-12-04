using Data.Enums;
using GameInfoModels.Interface;
using GameLogic.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace GameLogic.State
{
    public class SquadStateManager
    {
        private readonly ISquadUnitsProvider _playerProvider;

        private BaseState _currentState;

        private List<BaseState> _allStates;

        private Rigidbody _squadRigidbody;
        public SquadStateManager(IEnemyProvider enemyProvider, ISquadUnitsProvider squadProvider, Rigidbody rigidbody,
                                    float velocity, float squadChaseRadius, float attackRadius, float squadAttackRadius)
        {
            _playerProvider = squadProvider;
            _squadRigidbody = rigidbody;

            _allStates = new List<BaseState>()
            {
                new SquadWalkState(velocity,squadChaseRadius,rigidbody,enemyProvider, this),
                new SquadChaseState(velocity,squadAttackRadius,rigidbody,enemyProvider, this),
                new SquadAttackState(enemyProvider,squadProvider,attackRadius,this)
            };

            _currentState = _allStates.FirstOrDefault(state => state.GameState == GameState.Walk);
        }
        public void RunState()
        {
            _currentState.RunCurrentState();
        }
        public void SwitchState(GameState gameState)
        {
            var currentState = _allStates.FirstOrDefault(s => s.GameState == gameState);
            _currentState = currentState;
            ChangePlayerBehaviour();
        }
        private void ChangePlayerBehaviour()
        {
            switch (_currentState.GameState)
            {
                case GameState.Walk:
                    _playerProvider.Units[0].PlayerObject.transform.localPosition = Vector3.zero;
                    break;
                case GameState.Chase:
                    _playerProvider.Units[0].PlayerObject.transform.localPosition = Vector3.zero;
                    break;
                case GameState.Attack:
                    _squadRigidbody.velocity = Vector3.forward;
                    break;
                default:
                    break;
            }
        }
    }
}
