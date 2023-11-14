using GameLogic.Interfaces;
using Models.Interfaces;

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
        public IEnemy EnemyGeneration(IRoadController roadController)
        {
            if (roadController == null)
            {
                return null;
            }
            if (!_randomGeneration.IsCreateObject(chance))
            {
                return null;
            }
            return _createEnemy.CreateEnemyOnScene(roadController.WayPoint);
        }

    }
}
