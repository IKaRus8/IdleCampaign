using Data.Enums;
using GameInfoModels.Interface;
using UnityEngine;

namespace GameLogic.Services
{
    public class SquadWalkState : BaseState
    {
        private readonly SquadStateManager _squadStateManager;
        private readonly IEnemyProvider _enemyProvider;
        private readonly Rigidbody _playerRigidbody;
        private readonly float velocity;
        private readonly float _approachRadius;
        private bool _isSeeTheEnemy = false;
        public SquadWalkState(float Velocity, float approachRadius, Rigidbody playerRigidbody, 
                                IEnemyProvider enemyProvider, SquadStateManager squadStateManager) : base(GameState.Walk)
        {
            _enemyProvider = enemyProvider;
            _squadStateManager = squadStateManager;
            _approachRadius = approachRadius;
            _playerRigidbody = playerRigidbody;
            velocity = Velocity;
        }
        public override void RunCurrentState()
        {
            CheckForEnemyInRadius();
            if (!_isSeeTheEnemy)
            {
                _playerRigidbody.velocity = Vector3.forward * velocity;
                return;
            }
            _squadStateManager.SwitchState(GameState.Chase);
        }
        private void CheckForEnemyInRadius()
        {
            if (!_enemyProvider.IsEnemyNotExist)
            {
                if (Vector3.Distance(_enemyProvider.SquadEnemy.position, _playerRigidbody.position) <= _approachRadius)
                {
                    _isSeeTheEnemy = true;
                    return;
                }
            }
            _isSeeTheEnemy = false;
            return;
        }
    }
}
