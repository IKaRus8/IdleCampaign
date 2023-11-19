using GameInfoModels.Interface;
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
        private readonly TestService _testService;
        private IEnemyProvider _enemyProvider;

        private string enemyKey = "DogPolyart";
        private bool isSpawnEnemy = false;
        public EnemyManager(ISegmentContainer segmentContainer, IEnemySpawner enemySpawner, 
                            IEnemyProvider enemyProvider, TestService testService)
        {
            _enemyProvider = enemyProvider;
            _enemySpawner = enemySpawner;
            _testService = testService;

            _disposable = segmentContainer.EdgeSegmentPos.Subscribe(SpawnEnemy);
        }
        public async void SpawnEnemy(float edgeSegmentPos)
        {
            if (edgeSegmentPos == 0 || isSpawnEnemy)
            {
                return;
            }
            Vector3 enemyPos = new Vector3(0, 0, -edgeSegmentPos);
            IEnemy enemy = await _enemySpawner.Spawn(enemyPos, enemyKey);
            if (enemy == null)
            {
                return;
            }
            isSpawnEnemy = true;
            _enemyProvider.Enemies.Add(enemy);

            if (_testService != null)
                _testService.RunMethodAfterSeconds(EnemyDestroy, 0, 15);
        }
        public void EnemyDestroy(int index)
        {
            var enemy = _enemyProvider.Enemies[index];
            UnityEngine.Object.Destroy(enemy.enemyObject);

            _enemyProvider.Enemies.Remove(enemy);
            if (_enemyProvider.Enemies.Count == 0)
                isSpawnEnemy = false;
        }
        public void Dispose()
        {
            _disposable?.Dispose();
        }

    }
}
