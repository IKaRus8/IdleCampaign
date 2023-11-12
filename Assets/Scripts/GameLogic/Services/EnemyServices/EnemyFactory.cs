using GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Interfaces;
using UnityEngine;

namespace GameLogic.Services
{
    public class EnemyFactory : ICreateEnemy
    {
        private readonly IUIPrefabs _uiPrefabs;
        private readonly IUIContainerObjectsParents _uiContainerObjectsParents;

        public EnemyFactory(IUIPrefabs uiPrefabs, IUIContainerObjectsParents uiContainerObjectsParents)
        {
            _uiPrefabs = uiPrefabs;
            _uiContainerObjectsParents = uiContainerObjectsParents;
        }

        public void CreateEnemyOnScene()
        {
            if (_uiPrefabs.EnemyPrefab != null)
            {
                GameObject enemy = GameObject.Instantiate(_uiPrefabs.EnemyPrefab, _uiContainerObjectsParents.EnemyContainer);
            }
        }
    }
}
