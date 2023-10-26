using JetBrains.Annotations;
using UI.Interfaces;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;
using UnityEngine.ResourceManagement.ResourceProviders;
using System.Diagnostics;
using System;
using Assets.Scripts.UI.Services;

namespace UI.Services

{
    [UsedImplicitly]
    public class SceneLoadService : ISceneLoadService
{

        private const string LevelSceneAssetKey = "RoadScene";
        private const string MenuSceneAssetKey = "MenuScene";

        public void LoadLevelScene()
        {
            LoadSceneAsync(LevelSceneAssetKey).Forget();
        }

        public void LoadMenuScene()
        {
            LoadSceneAsync(MenuSceneAssetKey).Forget();
        }

        private async UniTaskVoid LoadSceneAsync(string sceneKey)
        {
            var handler = Addressables.LoadSceneAsync(sceneKey);
            await UniTask.WaitUntil(() => handler.IsDone);
        }
    }
}
