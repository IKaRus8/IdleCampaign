using Models.Interfaces;
using UnityEngine;

namespace Models
{
    public class Enemy : IEnemy
    {
        public GameObject EnemyObject { get; set; }
        public bool IsDead { get; set; }
        public float MaxHealth { get; }
        public float CurrentHealth { get; private set; }
        public float Attack { get; }
        public Vector3 EnemyPosition => EnemyObject.transform.position;
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
            }
        }
    }
}