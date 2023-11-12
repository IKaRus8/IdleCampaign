using UnityEngine;

namespace GameLogic.Controllers
{
    public class PlayerSquadController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        public float Velocity => 20f;

        private void Update()
        {
            _rigidbody.velocity = Vector3.forward * Velocity;
        }
    }
}