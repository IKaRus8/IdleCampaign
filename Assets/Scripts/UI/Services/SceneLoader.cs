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
    private string playerKey = "PlayerSquad";
    private string environmentKey = "Environment";

    private Dictionary<string, Transform> initObjects;

    public AsyncLazy Initialization { get; }

    private SceneLoader(IResourceLoadService resourceLoadService, IUIContainerObjectsParents uiContainerObjectsParents)
    {
        Initialization = UniTask.Lazy(() => LoadResources(uiContainerObjectsParents,resourceLoadService));
    }
    private async UniTask LoadResources(IUIContainerObjectsParents uiContainerObjectsParents, IResourceLoadService resourceLoadService)
    {
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
            { playerKey, uiContainerObjectsParents.PlayerParent },
            { environmentKey, uiContainerObjectsParents.EnvironmnetParent }
        };
    }
}
