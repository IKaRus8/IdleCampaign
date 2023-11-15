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
        public IPresenceOfEnemy _presenceOfEnemy;
        public float Velocity => 20f;

        [Inject]
        void Construct(IPresenceOfEnemy presenceOfEnemy)
        {
            _presenceOfEnemy = presenceOfEnemy;
        }
        private void Awake()
        {
            playerState = new PlayerState(Velocity, _presenceOfEnemy);
        }
        private void FixedUpdate()
        {
            playerState.Movement(_rigidbody);
        }
    }
}