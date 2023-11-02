using GameLogic.Controllers;
using GameLogic.Interfaces;
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
        }
    }
}