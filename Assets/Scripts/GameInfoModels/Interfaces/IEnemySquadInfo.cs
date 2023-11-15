using Models.Interfaces;
using System.Collections.Generic;

namespace GameInfoModels.Interface
{
    public interface IEnemySquadInfo
    {
        public List<IEnemy> Enemies { get; }

        public float SquadHealth { get; }

    }
}
