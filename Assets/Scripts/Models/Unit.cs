using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Models
{
    public class Unit : IUnit
    {
        public IEnemy TargetToPursue { get; set; }
        public GameObject PlayerObject { get; set; }
        public float MaxHealth { get; }
        public float Attack { get; }
        public NavMeshAgent Agent => PlayerObject.GetComponent<NavMeshAgent>();
        public Vector3 PlayerPosition => PlayerObject.transform.position;
        public Unit(GameObject playerObject)
        {
            PlayerObject = playerObject;
        }
    }
}
