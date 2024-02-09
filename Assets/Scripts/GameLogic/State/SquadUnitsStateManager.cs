using Data.Enums;
using GameInfoModels.Interfaces;
using GameInfoModels.Interfaces;
using GameLogic.Interfaces;
using Models;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic.State
{
    public class SquadUnitsStateManager
    {
        private readonly ISquadUnitsProvider _squadUnitsProvider;
        private readonly IEnemySquadsProvider _enemySquadsProvider;

        private readonly Rigidbody _squadRigidbody;

        private readonly float _squadChaseRadius;
        private readonly float _squadAttackRadius;

        private BaseState _currentState;

        private Dictionary<GameState, BaseState> _allStates;

        public SquadUnitsStateManager(IEnemySquadsProvider enemySquadsProvider, ISquadUnitsProvider squadUnitsProvider, Rigidbody squadRigidbody,
                                    float squadVelocity, float squadChaseRadius, float squadAttackRadius, float unitAttackRadius)
        {
            _enemySquadsProvider = enemySquadsProvider;
            _squadUnitsProvider = squadUnitsProvider;
            _squadChaseRadius = squadChaseRadius;
            _squadAttackRadius = squadAttackRadius;
            _squadRigidbody = squadRigidbody;

            _allStates = new Dictionary<GameState, BaseState>()
            {
                { GameState.Walk, new SquadWalkState(squadVelocity,squadRigidbody) },
                { GameState.Chase, new SquadChaseState(squadVelocity,squadRigidbody) },
                { GameState.Attack, new SquadAttackState(enemySquadsProvider,squadUnitsProvider,unitAttackRadius,squadAttackRadius) }
            };

            _currentState = _allStates[GameState.Walk];
        }
        public void RunState()
        {
            CheckEnemy();
            _currentState.RunCurrentState();
        }
        private void CheckEnemy()
        {
            if (_enemySquadsProvider.EnemySquads.Count()!=0)
            {
                var enemyContainerPosition = _enemySquadsProvider.EnemySquads[0].Enemies[0].EnemyPosition;
                var distance = Vector3.Distance(enemyContainerPosition, _squadRigidbody.position);
                switch (_currentState.GameState)
                {
                    case GameState.Walk:
                        CheckEnemyForWalkState(distance);
                        break;
                    case GameState.Chase:
                        CheckEnemyForChaseState(distance);
                        break;
                    case GameState.Attack:
                        CheckEnemyForAttackState(distance);
                        break;
                    default:
                        break;
                }
                return;
            }
            SwitchState(GameState.Walk);
        }
        private void CheckEnemyForWalkState(float distance)
        {
            if (distance > _squadChaseRadius)
            {
                return;
            }
            SwitchState(GameState.Chase);
        }
        private void CheckEnemyForChaseState(float distance)
        {
            if (distance < _squadAttackRadius)
            {
                SwitchState(GameState.Attack);
                return;
            }
            if(distance< _squadChaseRadius)
            {
                return;
            }
            SwitchState(GameState.Walk);
        }
        private void CheckEnemyForAttackState(float distance)
        {
            if (distance < _squadAttackRadius)
            {
                return;
            }
            SwitchState(GameState.Walk);
        }
        public void SwitchState(GameState gameState)
        {
            if (_currentState.GameState != gameState)
            {
                _currentState = _allStates[gameState];
                ChangePlayerBehaviour();
            }
        }
        private void ChangePlayerBehaviour()
        {
            switch (_currentState.GameState)
            {
                case GameState.Walk:
                    ChangeStateInWalk();
                    break;
                case GameState.Attack:
                    ChangeStateInAttack();
                    break;
                default:
                    break;
            }
            Debug.Log(_currentState.GameState);
        }
        private void ChangeStateInWalk()
        {
            _squadUnitsProvider.RemoveDeadUnits();
            _squadUnitsProvider.ResetUnitsPosition();
        }
        private void ChangeStateInAttack()
        {
            _squadRigidbody.velocity = Vector3.forward;
        }
    }
}
