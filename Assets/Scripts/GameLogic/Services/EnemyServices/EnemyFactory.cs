using GameLogic.Interfaces;
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
    public class EnemyFactory : ICreateEnemy
    {
        private readonly IUIContainerPrefabs _uiPrefabs;
        private readonly IUIContainerObjectsParents _uiContainerObjectsParents;

        public EnemyFactory(IUIContainerPrefabs uiPrefabs, IUIContainerObjectsParents uiContainerObjectsParents)
        {
            _uiPrefabs = uiPrefabs;
            _uiContainerObjectsParents = uiContainerObjectsParents;
        }

        public void CreateEnemyOnScene(float wayPoint)
        {
            if (_uiPrefabs.EnemyPrefab != null)
            {
                GameObject enemy = GameObject.Instantiate(_uiPrefabs.EnemyPrefab, _uiContainerObjectsParents.EnemiesParent);
                ChangeContainerLocation(wayPoint);
            }
        }
        private void ChangeContainerLocation(float wayPoint)
        {
            Vector3 newPos = new Vector3(0,0, wayPoint);
            _uiContainerObjectsParents.EnemyContainerParent.localPosition = newPos;
        }
    }
}
