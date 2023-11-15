using GameInfoModels.Interface;
using Models.Interfaces;
using System.Collections.Generic;

namespace GameInfoModels
{
    public class EnemySquadInfo : IEnemySquadInfo
    {
        public List<IEnemy> Enemies { get; set; } = new List<IEnemy>();

        public float SquadHealth { get; }


    }
}