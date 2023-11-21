using GameInfoModels.Interface;
using GameLogic.Interfaces;
using GameLogic.Services;
using UnityEngine;
using Zenject;

namespace GameLogic.Controllers
{
    public class PlayerSquadController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private float _approachRadius;

        private PlayerStateManager _playerStateManager;
        private IEnemyProvider _enemyProvider;
        public float Velocity => 20f;

        [Inject]
        void Construct(IEnemyProvider enemyProvider)
        {
            _enemyProvider = enemyProvider;
        }
        private void Awake()
        {
            _playerStateManager = new PlayerStateManager(_enemyProvider, Velocity, _approachRadius);
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