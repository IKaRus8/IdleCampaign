using System;
using UnityEngine;

namespace GameLogic.Controllers
{
    public class PlayerSquadController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private Transform _unitCreationArea;

        public float speed;
        
        private Vector3 startPosZArea;
        private void Awake()
        {
            startPosZArea = _unitCreationArea.localPosition;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = Vector3.forward * speed;
            _unitCreationArea.localPosition = new Vector3(startPosZArea.x, startPosZArea.y, startPosZArea.z + transform.localPosition.z);
        }
    }
}