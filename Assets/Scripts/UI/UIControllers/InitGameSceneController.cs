using System.Threading.Tasks;
using UI.Interfaces;
using UnityEngine;
using Zenject;

public class InitGameSceneController : MonoBehaviour
{
    public GameObject LoadPanel;
    [Inject]
    private async void Construct(IAsyncInitialization asyncInitializations)
    {
        LoadPanel.SetActive(true);
        await asyncInitializations.Initialization;
        LoadPanel.SetActive(false);
    }
}
