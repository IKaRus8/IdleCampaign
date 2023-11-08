using System.Collections.Generic;
using UI.Interfaces;
using UnityEngine;
using Zenject;

public class StartSceneController : MonoBehaviour
{
    [Inject]
    private async void Construct(IAsyncInitialization asyncInitializations)
    {
            await asyncInitializations.Initialization;
    }
}
