using Codice.Client.Common;
using GameInfoModels.Interfaces;
using GameLogic.Interfaces;
using Models.Interfaces;
using System;
using UniRx;
using UnityEngine;

namespace GameLogic.Services
{
    public class EnemyManager : IDisposable
    {
        private readonly IDisposable _disposable;
        private readonly IEnemySpawner _enemySpawner;
        private IEnemySquadsProvider _enemySquadsProvider;

        private string enemyKey = "DogPolyartEnemy";
        public EnemyManager(ISegmentContainer segmentContainer, IEnemySpawner enemySpawner,
							IEnemySquadsProvider enemySquadsProvider)
        {
            _enemySquadsProvider = enemySquadsProvider;
            _enemySpawner = enemySpawner;

            _disposable = segmentContainer.EdgeSegmentPos.Subscribe(SpawnEnemy);
        }
        public async void SpawnEnemy(float edgeSegmentPos)
        {
			if (edgeSegmentPos == 0)
            {
                return;
            }
            Vector3 enemyPos = new Vector3(0, 0, edgeSegmentPos);
            IEnemy enemy = await _enemySpawner.Spawn(enemyPos, enemyKey);

            if (enemy == null)
            {
                return;
            }
            var squadEnemy = _enemySquadsProvider.CreateNewSquad();
			squadEnemy.Enemies.Add(enemy);

        }
        public void EnemyDestroy(IEnemy enemyDestroy)
        {
            enemyDestroy.IsDead = true;
            UnityEngine.Object.Destroy(enemyDestroy.EnemyObject);
        }
        public void Dispose()
        {
            _disposable?.Dispose();
        }

    }
}
