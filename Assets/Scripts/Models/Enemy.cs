using Models.Interfaces;
using UnityEngine;

namespace Models
{
    public class Enemy : IEnemy
    {
        public GameObject enemyObject { get; set; }
        public float MaxHealth { get; }
        public float Attack { get; }

        public Enemy(GameObject enemyObject,Vector3 Position)
        {
            this.enemyObject = enemyObject;
            this.enemyObject.transform.localPosition = Position;

        }
    }
}