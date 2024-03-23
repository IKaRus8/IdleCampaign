using GameLogic.Interfaces;
using GameInfoModels;
using GameInfoModels.Interfaces;
using GameLogic.Controllers;
using GameLogic.Services;
using UI.Interfaces;
using UnityEngine;
using Zenject;
using UI.Services;
using GameLogic.StateEnemy;
using GameLogic.State;

namespace DI.Installers
{
    public class RoadSceneMainInstaller : MonoInstaller<RoadSceneMainInstaller>
    {
        [SerializeField]
        private UIContainer uiContainer;
        [SerializeField]
        private SegmentContainer segmentContainer;
        [SerializeField]
        private EnemyOptions enemyOptions;
        [SerializeField]
        private UnitOptions unitOptions;
        public override void InstallBindings()
        {
            Container.Bind<ISegmentContainer>().FromInstance(segmentContainer).AsSingle();
			Container.Bind<IEnemyOptions>().FromInstance(enemyOptions).AsSingle();
			Container.Bind<IUnitOptions>().FromInstance(unitOptions).AsSingle();

			//Bind Containers
			Container.BindInterfacesTo<UIContainer>().FromInstance(uiContainer).AsSingle();
            
            //Bind resources
            Container.Bind<IAsyncInitialization>().To<SceneLoader>().AsSingle();

            //Bind models
            Container.Bind<ISquadUnitsProvider>().To<SquadUnitsProvider>().AsSingle();
            Container.Bind<IEnemySquadsProvider>().To<EnemySquadsProvider>().AsSingle();

            //Bind GameLogic services
            Container.Bind<ISquadEnemyStateManager>().To<SquadEnemyStateManager>().AsSingle();
            Container.Bind<ISquadUnitsStateManager>().To<SquadUnitsStateManager>().AsSingle();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<IEnemySpawner>().To<EnemySpawner>().AsSingle();
            Container.Bind<EnemyManager>().AsSingle().NonLazy();
            Container.Bind<RandomGeneration>().AsSingle();


        }

    }
}