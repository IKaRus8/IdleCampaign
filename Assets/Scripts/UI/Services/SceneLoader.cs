using GameLogic.Interfaces;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using System.Collections.Generic;
using UI.Interfaces;
using UnityEngine;

namespace UI.Services
{
    [UsedImplicitly]
    public class SceneLoader : IAsyncInitialization
    {
        private string playerKey = "DogPBR";

        private Dictionary<string, Transform> initObjects;

        public AsyncLazy Initialization { get; }

        private SceneLoader(IResourceLoadService resourceLoadService, IUIContainerObjectsParents uiContainerObjectsParents, ISquadProvider playerProvider)
        {
            Initialization = UniTask.Lazy(() => LoadResources(uiContainerObjectsParents, resourceLoadService, playerProvider));
        }
        private async UniTask LoadResources(IUIContainerObjectsParents uiContainerObjectsParents, IResourceLoadService resourceLoadService, ISquadProvider playerProvider)
        {
            //initObjects = await GetFillDictionary(uiContainerObjectsParents);

            var player = await resourceLoadService.InstantiateAssetAsync(playerKey, uiContainerObjectsParents.PlayerParent);
            playerProvider.AddUnit(player);
        }

        //private async UniTask<Dictionary<string, Transform>> GetFillDictionary(IUIContainerObjectsParents uiContainerObjectsParents)
        //{
        //    return new Dictionary<string, Transform>
        //    {
        //        { playerKey, uiContainerObjectsParents.PlayerParent }
        //    };
        //}
    }
}
