using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using UnityMvvmToolkit.Core;
using UnityMvvmToolkit.Core.Interfaces;
using Zenject;
using UnityMvvmToolkit.UITK;

namespace Assets.Scripts.GameLogic.UI
{
    public class UserInterfaceController : IBindingContext
    {
        public ICommand AddUnitCommand { get; set; }

        public UserInterfaceController()
        {
            AddUnitCommand = new Command(AddUnit);
        }
        private void AddUnit()
        {
            Debug.Log("Add unit");
        }

    }
}