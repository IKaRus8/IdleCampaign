using System;
using GameLogic.Interfaces;
using Models.Constants;
using UnityEngine;

namespace GameLogic.Controllers
{
    public class RoadController : MonoBehaviour, IRoadController
    {
        private Transform _transform;
        
        public bool IsActive { get; set; }

        public float WayPoint => _transform.localPosition.z;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(TagsConstants.PlayerTag))
            {
                IsActive = true;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag(TagsConstants.PlayerTag))
            {
                IsActive = false;
            }
        }

        public void SetPosition(Vector3 position)
        {
            _transform.localPosition = position;
        }
    }
}