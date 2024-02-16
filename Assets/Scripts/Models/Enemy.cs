using Data.Enums;
using Models.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Models
{
    public class Enemy : IEnemy
    {
		private IUnit targetToPursue;

		public GameObject EnemyObject { get; set; }
        public bool IsDead { get; set; }
        public float CurrentHealth { get; private set; }
        public Vector3 EnemyPosition => EnemyObject.transform.position;
		public NavMeshAgent Agent { get; }
		public Rigidbody Rigidbody { get; }

		public IUnit TargetToPursue
		{
			get
			{
				if (targetToPursue == null)
				{
					return null;
				}
				if (targetToPursue.IsDead)
				{
					targetToPursue = null;
					return null;
				}
				return targetToPursue;
			}
			set { targetToPursue = value; }
		}

		public float MaxHealth { get; }
        public float Attack { get; }
		public GameState EnemyState { get; set; }

		public Enemy(GameObject enemyObject,Vector3 Position)
        {
            EnemyObject = enemyObject;
            EnemyState = GameState.Idle;
			EnemyObject.transform.localPosition = Position;
            IsDead = false;
            CurrentHealth = MaxHealth;
            Agent = EnemyObject.GetComponent<NavMeshAgent>();
			Rigidbody = EnemyObject.GetComponent<Rigidbody>();
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