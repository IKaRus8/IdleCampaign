using Codice.Client.Common.GameUI;
using Data.Enums;
using Models.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Models
{
    public class Unit : IUnit
    {
        private IEnemy targetToPursue;

        public IEnemy TargetToPursue
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
        public GameState UnitState { get; set; }
        public GameObject UnitObject { get; set; }
        public NavMeshAgent Agent => UnitObject.GetComponent<NavMeshAgent>();
        public Vector3 UnitPosition => UnitObject.transform.position;
        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; }
        public float Attack { get; }
        public bool IsDead { get; set; }
        public Unit(GameObject playerObject)
        {
            UnitObject = playerObject;
            UnitState = GameState.Idle;
            MaxHealth = 100;
            Attack = 20;
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
                GameObject.Destroy(UnitObject);
                UnitObject = null;
            }
        }
    }
}
