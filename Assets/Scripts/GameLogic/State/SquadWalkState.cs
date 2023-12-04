using Data.Enums;
using GameInfoModels.Interface;
using Models;
using UnityEngine;

namespace GameLogic.State
{
    public class SquadWalkState : BaseState
    {
        private readonly SquadStateManager _squadStateManager;
        private readonly IEnemyProvider _enemyProvider;
        private readonly Rigidbody _squadRigidbody;
        private readonly float velocity;
        private readonly float _approachRadius;
        private bool _isSeeTheEnemy = false;
        public SquadWalkState(float Velocity, float approachRadius, Rigidbody squadRigidbody, 
                                IEnemyProvider enemyProvider, SquadStateManager squadStateManager) : base(GameState.Walk)
        {
            _enemyProvider = enemyProvider;
            _squadStateManager = squadStateManager;
            _approachRadius = approachRadius;
            _squadRigidbody = squadRigidbody;
            velocity = Velocity;
        }
        public override void RunCurrentState()
        {
            CheckForEnemyInRadius();
            if (!_isSeeTheEnemy)
            {
                _squadRigidbody.velocity = Vector3.forward * velocity;
                return;
            }
            _squadStateManager.SwitchState(GameState.Chase);
        }
        private void CheckForEnemyInRadius()
        {
            if (!_enemyProvider.IsEnemyNotExist)
            {
                if (Vector3.Distance(_enemyProvider.Enemies[0].EnemyPosition, _squadRigidbody.position) <= _approachRadius)
                {
                    _isSeeTheEnemy = true;
                    return;
                }
            }
            _isSeeTheEnemy = false;
        }
    }
}
