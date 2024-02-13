using Models.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Models
{
    public class Enemy : IEnemy
    {
        public GameObject EnemyObject { get; set; }
        public bool IsDead { get; set; }
        public float CurrentHealth { get; private set; }
        public Vector3 EnemyPosition => EnemyObject.transform.position;
		public NavMeshAgent Agent { get; }

        public float MaxHealth { get; }
        public float Attack { get; }


		public Enemy(GameObject enemyObject,Vector3 Position)
        {
            EnemyObject = enemyObject;
            EnemyObject.transform.localPosition = Position;
            IsDead = false;
            CurrentHealth = MaxHealth;
            Agent = EnemyObject.GetComponent<NavMeshAgent>();

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