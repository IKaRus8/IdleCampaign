using Assets.Scripts.UI.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class SpawnObjectAdressables : MonoBehaviour
{
    [SerializeField]
    private Transform level;
    [SerializeField]
    private Transform characters;

    private string playerKey = "PlayerSquad";
    private string environmentKey = "Environment";


    private ResourceLoadService _resourceLoadService;
    
    [Inject]
    private void Construct(ResourceLoadService resourceLoadService)
    {
        _resourceLoadService = resourceLoadService;
    }
    private async void OnEnable()
    {
           await _resourceLoadService.InstantiateAssetAsync(playerKey, characters);
           await _resourceLoadService.InstantiateAssetAsync(environmentKey, level);
    }
}
public class SpawnObjectInfo
{
    public string key;
    public Transform parent;
}
