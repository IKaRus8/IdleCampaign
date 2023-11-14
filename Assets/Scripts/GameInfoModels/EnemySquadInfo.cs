using Models.Interfaces;
using System.Collections.Generic;

namespace GameInfoModels
{
    public class EnemySquadInfo
    {
        public List<IEnemy> Enemies { get; set; }

        public float SquadHealth { get; }


    }
}