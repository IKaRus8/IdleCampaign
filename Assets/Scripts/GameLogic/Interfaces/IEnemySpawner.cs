using Cysharp.Threading.Tasks;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic.Interfaces
{
    public interface IEnemySpawner
    {
       UniTask<IEnemy> Spawn(Vector3 enemyPosition, string enemyKey);
    }
}
