using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace UI.Interfaces
{
    public interface IResourceLoadService
    {
        UniTask<GameObject> InstantiateAssetAsync(string key, Transform parent);
        UniTask<List<T>> LoadAssetsAsync<T>(string label);
        UniTask<T> LoadAsyncComponent<T>(string key) where T : Component;
        UniTask<GameObject> LoadAsyncGO(string key);
        UniTask<T> LoadAsyncObject<T>(AssetReference assetReference) where T : Object;
        UniTask<T> LoadAsyncObject<T>(string key) where T : Object;
    }
}
