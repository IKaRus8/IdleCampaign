using System;
using UnityEngine;

namespace GameLogic.Controllers
{
    public class PlayerSquadController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        public float speed;
        private void Awake()
        {
            
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = Vector3.forward * speed;
        }
    }
}