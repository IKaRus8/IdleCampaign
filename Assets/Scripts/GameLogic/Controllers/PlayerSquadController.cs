using GameLogic.Interfaces;
using GameLogic.Services;
using UnityEngine;

namespace GameLogic.Controllers
{
    public class PlayerSquadController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        private PlayerState playerState;
        public float Velocity => 20f;

        private void Awake()
        {
            playerState = new PlayerState(Velocity);
        }
        private void Update()
        {
            playerState.Movement(_rigidbody);
            //_rigidbody.velocity = Vector3.forward * Velocity;
        }
    }
}