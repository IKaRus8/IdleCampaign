using UI.Interfaces;
using UnityEngine;

namespace UI.Models
{
    public class BaseScreen : MonoBehaviour, IBaseScreen
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}