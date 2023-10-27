using Assets.Scripts.UI.Services;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class SpawnObjectAdressables : MonoBehaviour
{
    [SerializeField]
    private Transform level;
    [SerializeField]
    private Transform characters;
    [SerializeField]
    private AssetLabelReference[] assetLabelReferences;

    private Dictionary<string, Transform> initObjects;

    private string playerKey = "PlayerSquad";
    private string environmentKey = "Environment";


    private ResourceLoadService _resourceLoadService;

    [Inject]
    private void Construct(ResourceLoadService resourceLoadService)
    {
        _resourceLoadService = resourceLoadService;

        FillDictionary();
    }
    private async void OnEnable()
    {
        foreach (var label in assetLabelReferences)
        {
            await _resourceLoadService.LoadAssetsAsync<Object>(label.labelString);
        }
        foreach (var obj in initObjects)
        {
            await _resourceLoadService.InstantiateAssetAsync(obj.Key, obj.Value);
        }
    }

    private void FillDictionary()
    {
        initObjects = new Dictionary<string, Transform>
        {
            { playerKey, characters },
            { environmentKey, level }
        };
    }
}
