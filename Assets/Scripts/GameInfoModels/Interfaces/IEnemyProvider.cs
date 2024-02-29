using Models.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace GameInfoModels.Interfaces
{
    public interface IEnemyProvider
    {
        List<IEnemy> Enemies { get; }
        bool IsEnemyNotExist { get; }
        //Vector3 EnemySquadPosition { get; }
		IEnemy NearestEnemy { get; }

		void RemoveDeadEnemies();
    }
}
