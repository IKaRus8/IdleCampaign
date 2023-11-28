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
            _playerStateManager = new PlayerStateManager(_enemyProvider, _playerProvider, Velocity, _approachRadius);
        }
        private void FixedUpdate()
        {
            _playerStateManager.Movement(_rigidbody);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _approachRadius);
        }
    }
}