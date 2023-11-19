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

        private PlayerState playerState;
        private IEnemyProvider _enemyProvider;
        public float Velocity => 20f;
        public float _approachRadius;

        [Inject]
        void Construct(IEnemyProvider enemyProvider)
        {
            _enemyProvider = enemyProvider;
        }
        private void Awake()
        {
            playerState = new PlayerState(_enemyProvider, Velocity, _approachRadius);
        }
        private void FixedUpdate()
        {
            playerState.Movement(_rigidbody);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _approachRadius);
        }
    }
}