using Assets.Scripts.UI.Services;
using GameLogic.Controllers;
using GameLogic.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UI.Services;
using UnityEngine;
using Zenject;

namespace DI.Installers

{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindServices();
        }

        private void BindServices()
        {
            Container.Bind<ResourceLoadService>().AsSingle();
            Container.Bind<SceneLoadService>().AsSingle();
        }
    }
}