using Cysharp.Threading.Tasks;
using GameLogic.Interfaces;
using Models;
using Models.Interfaces;
using UI.Interfaces;
using UnityEngine;

namespace GameLogic.Services
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IResourceLoadService _resourceLoadService;
        private readonly IUIContainerObjectsParents _uiContainerObjectsParents;
        public EnemyFactory(IResourceLoadService resourceLoadService, IUIContainerObjectsParents uiContainerObjectsParents)
        {
            _resourceLoadService = resourceLoadService;
            _uiContainerObjectsParents = uiContainerObjectsParents;
        }

        public async UniTask<IEnemy> CreateEnemy(Vector3 newPos, string enemyKey)
        {
            var enemy = await _resourceLoadService.InstantiateAssetAsync(enemyKey, _uiContainerObjectsParents.EnemiesParent);
            return new Enemy(enemy, newPos);
        }
    }
}
