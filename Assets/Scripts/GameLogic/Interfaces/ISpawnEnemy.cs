using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Interfaces
{
    public interface ISpawnEnemy
    {
        IEnemy EnemyGeneration(IRoadController roadController);
    }
}
