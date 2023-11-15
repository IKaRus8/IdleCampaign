using GameLogic.Interfaces;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Interfaces;
using UnityEngine;

namespace GameLogic.Services
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IUIContainerPrefabs _uiPrefabs;
        private readonly IUIContainerObjectsParents _uiContainerObjectsParents;

        public EnemyFactory(IUIContainerPrefabs uiPrefabs, IUIContainerObjectsParents uiContainerObjectsParents)
        {
            _uiPrefabs = uiPrefabs;
            _uiContainerObjectsParents = uiContainerObjectsParents;
        }

        public IEnemy CreateEnemyOnScene(Vector3 wayPoint)
        {
            if (_uiPrefabs.EnemyPrefab != null)
            {
                GameObject enemy = GameObject.Instantiate(_uiPrefabs.EnemyPrefab, _uiContainerObjectsParents.EnemiesParent);
                ChangeContainerLocation(wayPoint);
                return SetCreatedEnemy(enemy);
            }
            return null;
        }
        public IEnemy SetCreatedEnemy(GameObject enemyObject)
        {
            Enemy enemy = new Enemy();
            enemy.enemyObject = enemyObject;
            return enemy;
        }
        private void ChangeContainerLocation(Vector3 newPos)
        {
            _uiContainerObjectsParents.EnemyContainerParent.localPosition = newPos;
        }
    }
}
