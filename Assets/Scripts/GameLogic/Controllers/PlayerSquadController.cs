using GameInfoModels.Interface;
using GameLogic.Interfaces;
using GameLogic.State;
using UnityEngine;
using Zenject;

namespace GameLogic.Controllers
{
    public class PlayerSquadController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private float _squadChaseRadius;
        [SerializeField]
        private float _squadAttackRadius;
        [SerializeField]
        private float _unitAttackRadius;

        private IEnemyProvider _enemyProvider;
        private ISquadUnitsProvider _playerProvider;
        private SquadStateManager _playerStateManager;
        public float Velocity => 20f;

        [Inject]
        void Construct(IEnemyProvider enemyProvider, ISquadUnitsProvider playerProvider)
        {
            _enemyProvider = enemyProvider;
            _playerProvider = playerProvider;
        }
        private void Start()
        {
            _playerStateManager = new SquadStateManager(_enemyProvider, _playerProvider, _rigidbody, Velocity, _squadChaseRadius, _unitAttackRadius, _squadAttackRadius);
        }
        private void FixedUpdate()
        {
            _playerStateManager.RunState();
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _unitAttackRadius);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _squadAttackRadius);
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position, _squadChaseRadius);
        }
    }
}