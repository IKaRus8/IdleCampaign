using GameLogic.Controllers;
using GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using UI.Interfaces;
using UniRx;
using UnityEngine;
using Zenject;

namespace GameLogic.Services
{
    public class SpawnEnemy : IDisposable
    {
        [Range(0,100)]
        private const float chance = 70f;

        private readonly RandomGeneration _randomGeneration;
        private readonly ICreateEnemy _createEnemy;
        private readonly IDisposable _disposable;

        public SpawnEnemy(ISegmentContainer segmentContainer, RandomGeneration randomGeneration, ICreateEnemy createEnemy)
        {
            _randomGeneration = randomGeneration;
            _createEnemy = createEnemy;

            _disposable = segmentContainer.ActiveRoadRx.Subscribe(_ => EnemyGeneration());

        }
        private void EnemyGeneration()
        {
           if(!_randomGeneration.IsCreateObject(chance))
            {
                return;
            }
            _createEnemy.CreateEnemyOnScene();

           //добавление врага на сцену, размещение контейнера в нужном месте
        }
        public void Dispose()
        {
            _disposable?.Dispose();
        }

    }
}
