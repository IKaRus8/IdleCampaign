using GameLogic.Interfaces;
using Models.Interfaces;
using UnityEngine;

namespace GameLogic.Services
{
    public class SpawnEnemy : ISpawnEnemy
    {
        private const float chance = 60f;

        private readonly RandomGeneration _randomGeneration;
        private readonly IEnemyFactory _createEnemy;
        public SpawnEnemy(RandomGeneration randomGeneration, IEnemyFactory createEnemy)
        {
            _randomGeneration = randomGeneration;
            _createEnemy = createEnemy;
        }
        public IEnemy EnemyGeneration(Vector3 enemyPosition)
        {

            if (!_randomGeneration.IsCreateObject(chance))
            {
                return null;
            }
            return _createEnemy.CreateEnemyOnScene(enemyPosition);
        }

    }
}
