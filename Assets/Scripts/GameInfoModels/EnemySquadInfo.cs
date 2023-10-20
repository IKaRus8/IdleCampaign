using System.Collections.Generic;
using Models.Interfaces;

namespace GameInfoModels
{
    public class EnemySquadInfo
    {
        public List<IEnemy> Enemies { get; set; }
        
        public float SquadHealth { get; }
        
        
    }
}