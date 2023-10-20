using Models.Interfaces;

namespace Models
{
    public class Enemy : IEnemy
    {
        public float MaxHealth { get; }
        public float Attack { get; }
    }
}