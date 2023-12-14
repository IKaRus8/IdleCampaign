using Cysharp.Threading.Tasks;
using Models.Interfaces;
using UnityEngine;

namespace GameLogic.Interfaces
{
    public interface IEnemySpawner
    {
        UniTask<IEnemy> Spawn(Vector3 enemyPosition, string enemyKey);
    }
}
