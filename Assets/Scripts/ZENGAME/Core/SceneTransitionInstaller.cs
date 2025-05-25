using Zenject;

namespace ZENGAME.Core
{
    public class SceneTransitionInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneTransition>().AsSingle();
        }
    }
}