using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Models
{
    public class Player : IPlayer
    {
        public IEnemy TargetToPursue { get; set; }
        public GameObject PlayerObject { get; set; }
        public float MaxHealth { get; }
        public float Attack { get; }
        public Vector3 PlayerPosition => PlayerObject.transform.position;
        public Player(GameObject playerObject)
        {
            PlayerObject = playerObject;
        }
        public T GetComponent<T>() where T : Component
        {
            return PlayerObject.GetComponent<T>();
        }

    }
}
