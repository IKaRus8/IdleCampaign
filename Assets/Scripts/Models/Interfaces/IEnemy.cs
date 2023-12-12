using Codice.Client.BaseCommands.Differences;
using UnityEngine;

namespace Models.Interfaces
{
    public interface IEnemy : IDamagable
    {
        GameObject EnemyObject { get; set; }
        bool IsDead { get; set; }
        float MaxHealth { get; }
        float Attack { get; }
        Vector3 EnemyPosition { get; }
    }
}