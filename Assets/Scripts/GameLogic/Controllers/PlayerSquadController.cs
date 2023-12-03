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
        private ISquadProvider _playerProvider;
        private SquadStateManager _playerStateManager;
        public float Velocity => 20f;

        [Inject]
        void Construct(IEnemyProvider enemyProvider, ISquadProvider playerProvider)
        {
            _enemyProvider = enemyProvider;
            _playerProvider = playerProvider;
        }
        private void Start()
        {
            _playerStateManager = new SquadStateManager(_enemyProvider, _playerProvider, _rigidbody, Velocity, _approachRadius, _attackRadius);
        }
        private void FixedUpdate()
        {
            _playerStateManager.RunState();
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