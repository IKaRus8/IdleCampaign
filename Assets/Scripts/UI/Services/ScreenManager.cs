using System.Collections.Generic;
using Extensions;
using UI.Interfaces;
using UI.Models;
using UnityEngine;

namespace UI.Services
{
    public class ScreenManager : MonoBehaviour, IScreenManager
    {
        [SerializeField] 
        private List<BaseScreen> _screens = new();

        private void Awake()
        {
            _screens.CheckSelfAndItemsForNullOrEmpty();
        }

        public void Show<T>() where T : IBaseScreen
        {
            var opened = false;
            
            foreach (var screen in _screens)
            {
                if (screen is T)
                {
                    screen.Show();
                    
                    opened = true;
                    continue;
                }
                
                screen.Hide();
            }

            if (!opened)
            {
                Debug.LogWarning($"Not found screen {typeof(T)}");
            }
        }

        public void HideAll()
        {
            foreach (var screen in _screens)
            {
                screen.Hide();
            }
        }

        public void HideAllExcept<T>() where T : BaseScreen
        {
            foreach (var screen in _screens)
            {
                if (screen is T)
                {
                    continue;
                }
                
                screen.Hide();
            }
        }
    }
}