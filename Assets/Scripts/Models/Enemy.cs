using Models.Interfaces;
using UnityEngine;

namespace Models
{
    public class Enemy : IEnemy
    {
        public GameObject EnemyObject { get; set; }
        public bool IsDied { get; set; }
        public float MaxHealth { get; }
        public float Attack { get; }
        public Vector3 EnemyPosition => EnemyObject.transform.position;
        public Enemy(GameObject enemyObject,Vector3 Position)
        {
            EnemyObject = enemyObject;
            EnemyObject.transform.localPosition = Position;
            IsDied = false;
        }
    }
}