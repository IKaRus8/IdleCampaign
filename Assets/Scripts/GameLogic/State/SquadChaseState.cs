using GameLogic.Interfaces;
using Data.Enums;
using GameInfoModels.Interface;
using Models.Interfaces;
using UnityEngine;
using UnityEngine.AI;
using Models;

namespace GameLogic.State
{
    public class SquadChaseState : BaseState
    {
        private const float speedChase = 3f;
        private readonly SquadStateManager _squadStateManager;
        private readonly IEnemyProvider _enemyProvider;
        private readonly Rigidbody _squadRigidbody;
        private readonly float velocity;
        private readonly float _squadAttackRadius;
        private bool _isChaseEnemy = true;
        public SquadChaseState(float Velocity, float squadAttackRadius, Rigidbody squadRigidbody,
                                IEnemyProvider enemyProvider, SquadStateManager squadStateManager) : base(GameState.Chase)
        {
            _enemyProvider = enemyProvider;
            _squadStateManager = squadStateManager;
            _squadAttackRadius = squadAttackRadius;
            _squadRigidbody = squadRigidbody;
            velocity = Velocity;
        }
        public override void RunCurrentState()
        {
            CheckForEnemyInRadius();
            if (_isChaseEnemy)
            {
                _squadRigidbody.velocity = Vector3.forward * (velocity + speedChase);
                return;
            }
            _squadStateManager.SwitchState(GameState.Attack);
        }
        private void CheckForEnemyInRadius()
        {
                if (Vector3.Distance(_enemyProvider.Enemies[0].EnemyPosition, _squadRigidbody.position) <= _squadAttackRadius)
                {
                    _isChaseEnemy = false;
                    return;
                }
            _isChaseEnemy = true;
        }

    }
}
