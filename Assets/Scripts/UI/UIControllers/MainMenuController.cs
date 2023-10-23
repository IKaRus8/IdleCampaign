using UI.UIController;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    private TabbedMenuController _tabbedMenuController;
    void OnEnable()
    {
        UIDocument menu = GetComponent<UIDocument>();
        VisualElement root = menu.rootVisualElement;
        _tabbedMenuController = new(root);
    }

}
