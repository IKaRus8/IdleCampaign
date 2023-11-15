using Models.Interfaces;
using UnityEngine;

namespace Models
{
    public class Enemy : IEnemy
    {
        public GameObject enemyObject { get; set; }
        public float MaxHealth { get; }
        public float Attack { get; }

    }
}