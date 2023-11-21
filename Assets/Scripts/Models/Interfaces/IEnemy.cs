using Codice.Client.BaseCommands.Differences;
using UnityEngine;

namespace Models.Interfaces
{
    public interface IEnemy
    {
        public GameObject EnemyObject { get; set; }
        public float MaxHealth { get; }
        public float Attack { get; }
        public Vector3 EnemyPosition { get; }
    }
}