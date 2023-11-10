using GameLogic.Controllers;
using GameLogic.Interfaces;
using System.Collections.Generic;
using UI.Interfaces;
using UnityEngine;
using Zenject;

namespace DI.Installers
{
    public class RoadSceneMainInstaller : MonoInstaller<RoadSceneMainInstaller>
    {
        [SerializeField]
        private UIContainer uiContainer;

        public override void InstallBindings()
        {
            //Bind Containers
            Container.Bind<IUIContainerObjectsParents>().FromInstance(uiContainer);
            Container.Bind<ISegmentContainer>().To<SegmentContainer>().FromInstance(FindObjectOfType<SegmentContainer>()).AsSingle();

            //Bind resources
            Container.Bind<IAsyncInitialization>().To<SceneLoader>().AsSingle();
        }
    }
}