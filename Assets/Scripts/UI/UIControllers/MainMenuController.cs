using System;
using UI.Interfaces;
using UI.UIController;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UIElements;
using Zenject;

public class MainMenuController : MonoBehaviour
{
    private TabbedMenuController _tabbedMenuController;
    private ISceneLoadService _sceneLoadService;


    [Inject]
    void Construct(ISceneLoadService sceneLoadService)
    {
        _sceneLoadService = sceneLoadService;
    }

    private void Awake()
    {
        UIDocument menu = GetComponent<UIDocument>();
        VisualElement root = menu.rootVisualElement;
        _tabbedMenuController = new(root);

        InitElementsHome(root);
    }

    private void InitElementsHome(VisualElement root)
    {
        try
        {
            Button play = root.Q<Button>("PlayButton");
            play.RegisterCallback<ClickEvent>(OnPlayButtonClick);
        }
        catch(NullReferenceException)
        {
            Debug.Log("PlayButton null!");
        }
    }

    private void OnPlayButtonClick(ClickEvent evt)
    {
        LoadScene();
    }

    void LoadScene()
    {
        _sceneLoadService.LoadLevelScene();
    }
}
