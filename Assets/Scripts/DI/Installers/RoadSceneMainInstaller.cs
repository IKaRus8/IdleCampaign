using GameLogic.Controllers;
using GameLogic.Interfaces;
using Zenject;

namespace DI.Installers
{
    public class RoadSceneMainInstaller : MonoInstaller<RoadSceneMainInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ISegmentContainer>().To<SegmentContainer>().FromInstance(FindObjectOfType<SegmentContainer>()).AsSingle();
        }
    }
}