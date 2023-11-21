using GameInfoModels.Interface;
using Models.Interfaces;
using System.Collections.Generic;

namespace GameInfoModels
{
    public class EnemyProvider : IEnemyProvider
    {
        public List<IEnemy> Enemies { get; set; } = new List<IEnemy>();

        public float SquadHealth { get; }

        public bool IsEnemyNotExist  => Enemies.Count == 0;
    }
}