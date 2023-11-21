using Cysharp.Threading.Tasks;
using GameLogic.Interfaces;
using Models.Interfaces;
using UnityEngine;

namespace GameLogic.Services
{
    public class EnemySpawner : IEnemySpawner
    {
        private const float chance = 60f;

        private readonly RandomGeneration _randomGeneration;
        private readonly IEnemyFactory _enemyFactory;
        public EnemySpawner(RandomGeneration randomGeneration, IEnemyFactory enemyFactory)
        {
            _randomGeneration = randomGeneration;
            _enemyFactory = enemyFactory;
        }
        public async UniTask<IEnemy> Spawn(Vector3 enemyPosition, string enemyKey)
        {

            if (!_randomGeneration.IsRandomEventSuccessful(chance))
            {
                return null;
            }
            return await _enemyFactory.CreateEnemy(enemyPosition, enemyKey);
        }

    }
}
