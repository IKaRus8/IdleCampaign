using GameInfoModels.Interfaces;
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

        private IEnemySquadsProvider _enemySquadsProvider;
        private ISquadUnitsProvider _squadUnitsProvider;
        private SquadUnitsStateManager _squadUnitsStateManager;
        public float Velocity => 30f;

        [Inject]
        void Construct(IEnemySquadsProvider enemySquadsProvider, ISquadUnitsProvider squadUnitsProvider)
        {
            _enemySquadsProvider = enemySquadsProvider;
            _squadUnitsProvider = squadUnitsProvider;
        }
        private void Start()
        {
            _squadUnitsStateManager = new SquadUnitsStateManager(_enemySquadsProvider, _squadUnitsProvider, _rigidbody, Velocity, _squadChaseRadius, _squadAttackRadius, _unitAttackRadius);
        }
        private void FixedUpdate()
        {
            _squadUnitsStateManager.RunState();
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