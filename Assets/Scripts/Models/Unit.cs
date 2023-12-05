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
                if (targetToPursue.IsDied)
                {
                    targetToPursue = null;
                    return null;
                }
                return targetToPursue;
            }
            set{ targetToPursue = value; }
        }
    public GameState UnitState { get; set; }
    public GameObject UnitObject { get; set; }
    public NavMeshAgent Agent => UnitObject.GetComponent<NavMeshAgent>();
    public Vector3 UnitPosition => UnitObject.transform.position;
    public float MaxHealth { get; }
    public float Attack { get; }

    public Unit(GameObject playerObject)
    {
        UnitObject = playerObject;
    }
}
}
