using GameInfoModels;
using GameLogic.Interfaces;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;

namespace GameLogic.Services
{
    public class EnemyManager : IDisposable
    {
        private readonly IDisposable _disposable;
        private readonly ISpawnEnemy _spawnEnemy;

        private EnemySquadInfo _enemyInfo;
        public bool EnemyOnScene;
        public EnemyManager(ISegmentContainer segmentContainer, ISpawnEnemy spawnEnemy)
        {
            _enemyInfo = new EnemySquadInfo();
            _spawnEnemy = spawnEnemy;

            EnemyOnScene = false;
            _disposable = segmentContainer.ActiveRoadRx.Subscribe(SpawnEnemy);
        }
        public void SpawnEnemy(IRoadController roadController)
        {
            var enemy = _spawnEnemy.EnemyGeneration(roadController);
            if(enemy==null)
            {
                return;
            }
            _enemyInfo.Enemies.Add(enemy);
        }
        public void Dispose()
        {
            _disposable?.Dispose();
        }

    }
}
