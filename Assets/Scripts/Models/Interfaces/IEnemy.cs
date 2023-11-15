using UnityEngine;

namespace Models.Interfaces
{
    public interface IEnemy
    {
        public GameObject enemyObject { get; set; }
        public float MaxHealth { get; }
        
        public float Attack { get; }
    }
}