using GameLogic.Controllers;
using GameLogic.Interfaces;
using GameLogic.Services;
using UI.Interfaces;
using UnityEngine;
using Zenject;

namespace DI.Installers
{
    public class RoadSceneMainInstaller : MonoInstaller<RoadSceneMainInstaller>
    {
        [SerializeField]
        private UIContainer uiContainer;
        [SerializeField]
        private SegmentContainer segmentContainer;
        public override void InstallBindings()
        {
            //Bind Containers
            Container.Bind<ISegmentContainer>().FromInstance(segmentContainer).AsSingle();
            Container.BindInterfacesTo<UIContainer>().FromInstance(uiContainer).AsSingle();
            
            //Bind resources
            Container.Bind<IAsyncInitialization>().To<SceneLoader>().AsSingle();

            //Bind GameLogic services
            Container.Bind<RandomGeneration>().AsSingle();
            Container.Bind<ICreateEnemy>().To<EnemyFactory>().AsSingle();
            Container.BindInterfacesTo<SpawnEnemy>().AsSingle().NonLazy();

        }

    }
}