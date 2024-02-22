using Codice.Client.BaseCommands.Differences;
using Data.Enums;
using UnityEngine;
using UnityEngine.AI;

namespace Models.Interfaces
{
    public interface IEnemy : IDamageable
    {
		IUnit TargetToPursue { get; set; }
		GameState EnemyState { get; set; }
		GameObject EnemyObject { get; set; }
        NavMeshAgent Agent { get;}
		Rigidbody Rigidbody { get; }
		Vector3 EnemyPosition { get; }
		bool IsDead { get; set; }
		bool IsAttacking { get; set; }
        float MaxHealth { get; }
        float Attack { get; }

	}
}