using Codice.Client.BaseCommands.Differences;
using UnityEngine;
using UnityEngine.AI;

namespace Models.Interfaces
{
    public interface IEnemy : IDamageable
    {
        GameObject EnemyObject { get; set; }
        bool IsDead { get; set; }
        float MaxHealth { get; }
        float Attack { get; }
        Vector3 EnemyPosition { get; }
        NavMeshAgent Agent { get;}
		Rigidbody Rigidbody { get; }

	}
}