using Zenject;

namespace ZENGAME.Core.Installers
{
    public class SceneTransitionInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneTransition>().AsSingle();
        }
    }
}