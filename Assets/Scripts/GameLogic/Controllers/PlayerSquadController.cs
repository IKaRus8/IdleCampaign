using System;
using UnityEngine;

namespace GameLogic.Controllers
{
    public class PlayerSquadController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        private void Awake()
        {
            
        }

        private void Update()
        {
            _rigidbody.velocity = Vector3.forward * 20;
        }
    }
}