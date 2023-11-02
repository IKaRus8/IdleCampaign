using Assets.Scripts.UI.Services;
using UI.Interfaces;
using UI.Services;
using Zenject;

namespace DI.Installers

{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Initialize addressable
            AddressablesManager.InitAddressables();

            //Bind Services
            Container.Bind<IResourceLoadService>().To<ResourceLoadService>().AsSingle();
            Container.Bind<ISceneLoadService>().To<SceneLoadService>().AsSingle();
        }

    }
}