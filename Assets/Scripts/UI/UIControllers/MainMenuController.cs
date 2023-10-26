using Assets.Scripts.UI.Services;
using System;
using UI.Services;
using UI.UIController;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Zenject;

public class MainMenuController : MonoBehaviour
{
    private TabbedMenuController _tabbedMenuController;
    private SceneLoadService _sceneLoadService;

    private string key = "";

    [Inject]
    void Construct(SceneLoadService sceneLoadService)
    {
        _sceneLoadService = sceneLoadService;
    }

    void OnEnable()
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
