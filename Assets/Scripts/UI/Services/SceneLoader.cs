using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using UI.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class SceneLoader : MonoBehaviour
{

    private IResourceLoadService _resourceLoadService;
    private IUIContainerObjectsParents _uiContainerObjectsParents;

    private string playerKey = "PlayerSquad";
    private string environmentKey = "Environment";

    private Dictionary<string, Transform> initObjects;

    [Inject]
    private void Construct(IResourceLoadService resourceLoadService, IUIContainerObjectsParents uIContainerObjectsParents)
    {
        _resourceLoadService = resourceLoadService;
        _uiContainerObjectsParents = uIContainerObjectsParents;

        FillDictionary();
    }
    private void Awake()
    {
        LoadResources().Forget();
    }

    private async UniTaskVoid LoadResources()
    {
        foreach (var obj in initObjects)
        {
            await _resourceLoadService.InstantiateAssetAsync(obj.Key, obj.Value);
        }
    }

    private void FillDictionary()
    {
        initObjects = new Dictionary<string, Transform>
        {
            { playerKey, _uiContainerObjectsParents.GetPlayerParent() },
            { environmentKey, _uiContainerObjectsParents.GetEnvironmnetParent() }
        };
    }
}
