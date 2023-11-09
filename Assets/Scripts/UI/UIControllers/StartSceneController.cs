using System.Collections;
using System.Collections.Generic;
using UI.Interfaces;
using UnityEngine;
using Zenject;

public class StartSceneController : MonoBehaviour
{
    [Inject]
    private async void Construct(ISceneLoadService sceneLoadService)
    {
        sceneLoadService.LoadMenuScene();
    }
}