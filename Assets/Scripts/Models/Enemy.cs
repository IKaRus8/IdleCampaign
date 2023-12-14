using Models.Interfaces;
using UnityEngine;

namespace Models
{
    public class Enemy : IEnemy
    {
        public GameObject EnemyObject { get; set; }
        public bool IsDead { get; set; }
        public float CurrentHealth { get; private set; }
        public Vector3 EnemyPosition => EnemyObject.transform.position;

        public float MaxHealth { get; }
        public float Attack { get; }
        public Enemy(GameObject enemyObject,Vector3 Position)
        {
            EnemyObject = enemyObject;
            EnemyObject.transform.localPosition = Position;
            IsDead = false;
            CurrentHealth = MaxHealth;
        }

        public void TakeDamage(float damageAmount)
        {
            CurrentHealth -= damageAmount;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                IsDead = true;
                GameObject.Destroy(EnemyObject);
                EnemyObject = null;
            }
        }
    }
}