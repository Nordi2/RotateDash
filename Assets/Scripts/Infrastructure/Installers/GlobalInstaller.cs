using Assets.Scripts.GamePlay;
using Zenject;

namespace Assets.Scripts.Infrastructure.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScreenResolution>().AsSingle().NonLazy();
        }
    }
}