using GameInfoModels.Interface;
using GameLogic.Controllers;
using GameLogic.Interfaces;
using Models.Interfaces.Constants;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace GameLogic.Services
{
    public class EnemyManager : IDisposable, IPresenceOfEnemy
    {
        private readonly IDisposable _disposable;
        private readonly ISpawnEnemy _spawnEnemy;
        private IEnemySquadInfo _enemySquadInfo;

        public Vector3 enemyPosition { get; private set; }
        public ReactiveProperty<bool> EnemyOnScene { get;} = new ReactiveProperty<bool>(false);
        public EnemyManager(ISegmentContainer segmentContainer, ISpawnEnemy spawnEnemy, IEnemySquadInfo enemyInfo)
        {
            _enemySquadInfo = enemyInfo;
            _spawnEnemy = spawnEnemy;
            _disposable = segmentContainer.ActiveRoadRx.Subscribe(SpawnEnemy);
        }
        public void SpawnEnemy(IRoadController roadController)
        {
            if (roadController == null)
            {
                return;
            }
            Vector3 enemyPos = new Vector3(0,0, roadController.WayPoint);
            var enemy = _spawnEnemy.EnemyGeneration(enemyPos);
            if (enemy == null)
            {
                return;
            }
            _enemySquadInfo.Enemies.Add(enemy);
            if (!EnemyOnScene.Value)
            {
                enemyPosition = enemyPos;
                EnemyOnScene.Value = true;
            }
            Observable.Timer(System.TimeSpan.FromSeconds(5))
        .Subscribe(_ =>
        {
            EnemyDestroy();
        });
        }
        public void EnemyDestroy()
        {
            foreach (var enemy in _enemySquadInfo.Enemies)
            {
               UnityEngine.Object.Destroy(enemy.enemyObject);
            }
            _enemySquadInfo.Enemies.Clear();

            if (_enemySquadInfo.Enemies.Count==0)
            {
                EnemyOnScene.Value = false;
            }
        }
        public void Dispose()
        {
            _disposable?.Dispose();
        }

    }
}
