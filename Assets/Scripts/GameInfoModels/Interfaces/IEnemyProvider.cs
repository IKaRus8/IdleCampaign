using Models.Interfaces;
using System.Collections.Generic;

namespace GameInfoModels.Interface
{
    public interface IEnemyProvider
    {
        public List<IEnemy> Enemies { get; }

        public float SquadHealth { get; }

        public bool isEnemyNotExist => Enemies.Count == 0;
    }
}
