using GameInfoModels;
using GameInfoModels.Interface;
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
            Container.Bind<ISegmentContainer>().FromInstance(segmentContainer).AsSingle();

            //Bind Containers
            Container.BindInterfacesTo<UIContainer>().FromInstance(uiContainer).AsSingle();
            
            //Bind resources
            Container.Bind<IAsyncInitialization>().To<SceneLoader>().AsSingle();

            //Bind models
            Container.Bind<IEnemySquadInfo>().To<EnemySquadInfo>().AsSingle();

            //Bind GameLogic services
            Container.Bind<RandomGeneration>().AsSingle();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<ISpawnEnemy>().To<SpawnEnemy>().AsSingle();
            Container.Bind<IPresenceOfEnemy>().To<EnemyManager>().AsSingle();


        }

    }
}