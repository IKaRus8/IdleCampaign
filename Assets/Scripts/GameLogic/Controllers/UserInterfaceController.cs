using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using UnityMvvmToolkit.Core;
using UnityMvvmToolkit.Core.Interfaces;
using Zenject;
using UnityMvvmToolkit.UITK;

namespace GameLogic.Controllers
{
    public class UserInterfaceController : IBindingContext
    {
        public ICommand IncrementCommand { get; set; }

        public UserInterfaceController()
        {
            IncrementCommand = new Command(AddUnit);
        }
        private void AddUnit()
        {
            Debug.Log("Add unit");
        }

    }
}