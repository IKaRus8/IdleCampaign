using UnityEngine;
using UnityEngine.AI;

namespace Models.Interfaces
{
    public interface IUnit
    {
        IEnemy TargetToPursue { get; set; }
        GameObject PlayerObject { get; set; }
        NavMeshAgent Agent { get; }
        Vector3 PlayerPosition { get; }
        float MaxHealth { get; }
        float Attack { get; }

    }
}
