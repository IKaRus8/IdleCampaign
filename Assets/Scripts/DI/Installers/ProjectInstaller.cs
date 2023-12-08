using UI.Interfaces;
using UI.Services;
using Zenject;

namespace DI.Installers

{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Bind Services
            Container.Bind<AddressablesManager>().AsSingle().NonLazy();

            Container.Bind<IResourceLoadService>().To<ResourceLoadService>().AsSingle();
            Container.Bind<ISceneLoadService>().To<SceneLoadService>().AsSingle();
        }

    }
}