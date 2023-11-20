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

        private PlayerStateManager _playerStateManager;
        private IEnemyProvider _enemyProvider;
        public float Velocity => 20f;
        public float ApproachRadius;

        [Inject]
        void Construct(IEnemyProvider enemyProvider)
        {
            _enemyProvider = enemyProvider;
        }
        private void Awake()
        {
            _playerStateManager = new PlayerStateManager(_enemyProvider, Velocity, ApproachRadius);
        }
        private void FixedUpdate()
        {
            _playerStateManager.Movement(_rigidbody);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, ApproachRadius);
        }
    }
}