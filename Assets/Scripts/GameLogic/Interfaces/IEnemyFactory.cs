using Cysharp.Threading.Tasks;
using Models.Interfaces;
using UnityEngine;

namespace GameLogic.Interfaces
{
    public interface IEnemyFactory
    {
        UniTask<IEnemy> CreateEnemy(Vector3 enemyPosition, string enemyKey);
    }
}
