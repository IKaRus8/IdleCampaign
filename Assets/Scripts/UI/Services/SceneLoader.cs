using Assets.Scripts.UI.Services;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using UI.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

[UsedImplicitly]
public class SceneLoader : IAsyncInitialization
{
    private string playerKey = "DogPBR";
    private string enemyKey = "DogPolyart";

    private Dictionary<string, Transform> initObjects;

    public AsyncLazy Initialization { get; }

    private SceneLoader(IResourceLoadService resourceLoadService, IUIContainerObjectsParents uiContainerObjectsParents, IUIContainerPrefabs uiPrefabs)
    {
        Initialization = UniTask.Lazy(() => LoadResources(uiContainerObjectsParents,resourceLoadService, uiPrefabs));
    }
    private async UniTask LoadResources(IUIContainerObjectsParents uiContainerObjectsParents, IResourceLoadService resourceLoadService, IUIContainerPrefabs uiPrefabs)
    {
        uiPrefabs.EnemyPrefab = await resourceLoadService.LoadAsyncGO(enemyKey);

        initObjects = await GetFillDictionary(uiContainerObjectsParents);

        foreach (var obj in initObjects)
        {
            await resourceLoadService.InstantiateAssetAsync(obj.Key, obj.Value);
        }
    }

    private async UniTask<Dictionary<string, Transform>> GetFillDictionary(IUIContainerObjectsParents uiContainerObjectsParents)
    {
        return new Dictionary<string, Transform>
        {
            { playerKey, uiContainerObjectsParents.PlayerParent }
        };
    }
}
