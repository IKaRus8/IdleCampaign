using Codice.Client.BaseCommands.Differences;
using UnityEngine;

namespace Models.Interfaces
{
    public interface IEnemy
    {
        GameObject EnemyObject { get; set; }
        bool IsDied { get; set; }
        float MaxHealth { get; }
        float Attack { get; }
        Vector3 EnemyPosition { get; }
    }
}