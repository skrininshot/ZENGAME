using Zenject;

namespace ZENGAME.Core.Installers
{
    public class GameStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
            Container.BindFactory<GameStateTransition, GameStateTransition.Factory>().WhenInjectedInto<GameStateFactory>();
            Container.BindFactory<GameStatePlay, GameStatePlay.Factory>().WhenInjectedInto<GameStateFactory>();
        }
    }
}