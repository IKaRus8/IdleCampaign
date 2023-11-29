using Assets.Scripts.GameLogic.Interfaces;
using GameInfoModels.Interface;
using GameLogic.Interfaces;
using GameLogic.Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace GameLogic.Controllers
{
    public class PlayerSquadController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private float _approachRadius;
        [SerializeField]
        private float _attackRadius;

        private IEnemyProvider _enemyProvider;
        private IPlayerProvider _playerProvider;
        private PlayerStateManager _playerStateManager;
        public float Velocity => 20f;

        [Inject]
        void Construct(IEnemyProvider enemyProvider, IPlayerProvider playerProvider)
        {
            _enemyProvider = enemyProvider;
            _playerProvider = playerProvider;
        }
        private void Start()
        {
            _playerStateManager = new PlayerStateManager(_enemyProvider, _playerProvider, _rigidbody, Velocity, _approachRadius, _attackRadius);
        }
        private void FixedUpdate()
        {
            _playerStateManager.Movement();
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackRadius);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _approachRadius);
        }
    }
}