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
        private IEnemyProvider _enemyProvider;

        private string enemyKey = "DogPolyart";
        public EnemyManager(ISegmentContainer segmentContainer, IEnemySpawner enemySpawner, 
                            IEnemyProvider enemyProvider)
        {
            _enemyProvider = enemyProvider;
            _enemySpawner = enemySpawner;

            _disposable = segmentContainer.EdgeSegmentPos.Subscribe(SpawnEnemy);
        }
        public async void SpawnEnemy(float edgeSegmentPos)
        {
            if (edgeSegmentPos == 0)
            {
                return;
            }
            Vector3 enemyPos = new Vector3(0, 0, -edgeSegmentPos);
            IEnemy enemy = await _enemySpawner.Spawn(enemyPos, enemyKey);

            if (enemy == null)
            {
                return;
            }
            _enemyProvider.Enemies.Add(enemy);

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
