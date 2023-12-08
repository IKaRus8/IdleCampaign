using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using UI.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace UI.Services
{
    [UsedImplicitly]
    public class ResourceLoadService : IResourceLoadService, IDisposable
    {
        private readonly List<AsyncOperationHandle> _handles = new();
        public void Dispose()
        {
            foreach (var handle in _handles) Addressables.Release(handle);
        }

        public async UniTask<T> LoadAsyncComponent<T>(string key) where T : Component
        {
            var asset = await LoadAsyncGO(key);

            var component = asset.GetComponent<T>();

            if (component == null)
            {
#if UNITY_EDITOR || DEBUG
                throw new MissingComponentException($"Missing component {typeof(T)} in asset {key}");
#endif
                return default;
            }
            return component;
        }

        public async UniTask<GameObject> LoadAsyncGO(string key)
        {
            if (!AssetExists(key))
            {
                Debug.LogError($"asset {key} is null");
                return null;
            }
            var handle = Addressables.LoadAssetAsync<GameObject>(key);

            await handle.ToUniTask();

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
#if UNITY_EDITOR || DEBUG
                Debug.LogError($"{handle.OperationException}");
#endif
                Addressables.Release(handle);
                return null;
            }

            var asset = handle.Result;

            if (asset == null)
            {
#if UNITY_EDITOR || DEBUG
                Debug.LogError($"asset {key} is null");
#endif
                return null;
            }

            _handles.Add(handle);

            return asset;
        }

        public async UniTask<T> LoadAsyncObject<T>(string key) where T : Object
        {
            if (!AssetExists(key))
            {
                Debug.LogError($"asset {key} is null");
                return null;
            }
            var handle = Addressables.LoadAssetAsync<T>(key);

            await handle.ToUniTask();

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
#if UNITY_EDITOR || DEBUG
                Debug.LogError($"{handle.OperationException}");
#endif
                Addressables.Release(handle);
                return default;
            }

            var asset = handle.Result;

            if (asset == null)
            {
#if UNITY_EDITOR || DEBUG
                Debug.LogError($"asset {key} is null");
#endif
                return default;
            }

            _handles.Add(handle);

            return asset;
        }

        public async UniTask<List<T>> LoadAssetsAsync<T>(string label)
        {
            if (!AssetExists(label))
            {
                Debug.LogError($"label {label} is null");
                return null;
            }
            var handle = Addressables.LoadAssetsAsync<T>(label, null);

            await handle.ToUniTask();

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
#if UNITY_EDITOR || DEBUG
                Debug.LogError($"{handle.OperationException}");
#endif
                Addressables.Release(handle);
                return null;
            }

            var result = handle.Result;

            if (result == null)
            {
#if UNITY_EDITOR || DEBUG
                Debug.LogError($"asset {label} is null");
#endif
                return null;
            }

            _handles.Add(handle);

            return result.ToList();
        }

        public async UniTask<T> LoadAsyncObject<T>(AssetReference assetReference) where T : Object
        {
            var handle = Addressables.LoadAssetAsync<T>(assetReference);

            await handle.ToUniTask();

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
#if UNITY_EDITOR || DEBUG
                Debug.LogError($"{handle.OperationException}");
#endif
                Addressables.Release(handle);
                return default;
            }

            var asset = handle.Result;

            if (asset == null)
            {
#if UNITY_EDITOR || DEBUG
                Debug.LogError($"asset {assetReference.AssetGUID} is null");
#endif
                return default;
            }

            _handles.Add(handle);

            return asset;
        }

        public async UniTask<GameObject> InstantiateAssetAsync(string key, Transform parent)
        {
            if (!AssetExists(key))
            {
                Debug.LogError($"asset {key} is null");
                return null;
            }
            var handle = Addressables.InstantiateAsync(key, parent);

            await handle.ToUniTask();

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
#if UNITY_EDITOR || DEBUG
                Debug.LogError($"{handle.OperationException}");
#endif
                Addressables.Release(handle);
                return null;
            }

            var asset = handle.Result;

            if (asset == null)
            {
#if UNITY_EDITOR || DEBUG
                Debug.LogError($"asset {key} is null");
#endif
                return null;
            }

            return asset;
        }

        private static bool AssetExists(string key)
        {
            foreach (var l in Addressables.ResourceLocators)
                if (l.Locate(key, null, out _))
                    return true;

            return false;
        }
    }
}
