using Data.Enums;
using UnityEngine;
using UnityEngine.AI;

namespace Models.Interfaces
{
    public interface IUnit : IDamageable
    {
        IEnemy TargetToPursue { get; set; }
        GameState UnitState { get; set; }
        GameObject UnitObject { get; set; }
        bool IsDead { get; set; }
        bool IsAttacking { get; set; }
        NavMeshAgent Agent { get; }
        Vector3 UnitPosition { get; }
        float MaxHealth { get; }
        float Damage { get; }
		float TimeBetweenAttack { get; }

	}
}
