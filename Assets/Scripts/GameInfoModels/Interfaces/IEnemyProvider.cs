using Models.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace GameInfoModels.Interface
{
    public interface IEnemyProvider
    {
        List<IEnemy> Enemies { get; }
        Transform SquadEnemy { get; }

        float SquadHealth { get; }

        bool IsEnemyNotExist { get; }
    }
}
