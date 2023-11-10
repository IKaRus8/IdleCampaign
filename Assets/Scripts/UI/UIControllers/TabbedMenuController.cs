using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.UIController
{
    public class TabbedMenuController
    {
        private const string tabClassName = "tab";
        private const string currentlySelectedTabClassName = "currentlySelectedTab";
        private const string unselectedContentClassName = "unselectedContent";
        private const string tabNameSuffix = "Tab";
        private const string contentNameSuffix = "Content";

        private readonly VisualElement root;

        public TabbedMenuController(VisualElement root)
        {
            this.root = root;
            RegisterTabCallbacks();
        }

        public void RegisterTabCallbacks()
        {
            UQueryBuilder<Button> tabs = GetAllTabs();
            tabs.ForEach((Button tab) =>
            {
                tab.RegisterCallback<ClickEvent>(TabOnClick);
            });
        }
        private void TabOnClick(ClickEvent evt)
        {
            Button clickedTab = evt.currentTarget as Button;
            if (!TabIsCurrentlySelected(clickedTab))
            {
                GetAllTabs().Where(
                    (tab) => tab != clickedTab && TabIsCurrentlySelected(tab)
                ).ForEach(UnselectTab);
                SelectTab(clickedTab);
            }
        }
        private static bool TabIsCurrentlySelected(Button tab)
        {
            return tab.ClassListContains(currentlySelectedTabClassName);
        }

        private UQueryBuilder<Button> GetAllTabs()
        {
            return root.Query<Button>(className: tabClassName);
        }

        private void SelectTab(Button tab)
        {
            tab.AddToClassList(currentlySelectedTabClassName);
            VisualElement content = FindContent(tab);
            content.RemoveFromClassList(unselectedContentClassName);
        }

        private void UnselectTab(Button tab)
        {
            tab.RemoveFromClassList(currentlySelectedTabClassName);
            VisualElement content = FindContent(tab);
            content.AddToClassList(unselectedContentClassName);
        }

        private static string GenerateContentName(Button tab) =>
            tab.name.Replace(tabNameSuffix, contentNameSuffix);

        private VisualElement FindContent(Button tab)
        {
            return root.Q(GenerateContentName(tab));
        }
    }
}