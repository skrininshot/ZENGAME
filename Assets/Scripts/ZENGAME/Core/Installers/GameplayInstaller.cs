using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ZENGAME.Core.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private Button screenButton;
        [SerializeField] private UIMenuView uiMenuView;
        
        [SerializeField] private AttentionPointView attentionPointView;
        [SerializeField] private AttentionPointController.Settings attentionPointHandlerSettings;
        
        public override void InstallBindings()
        {
            Container.Bind<GameplayStateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameplayStateMachine>().AsSingle();
            Container.BindFactory<GameplayStateMenu, GameplayStateMenu.Factory>().WhenInjectedInto<GameplayStateFactory>();
            Container.BindFactory<GameplayStatePlay, GameplayStatePlay.Factory>().WhenInjectedInto<GameplayStateFactory>();

            Container.BindInstance(new PlayerScoreSystem()).AsSingle();
            
            Container.BindInstance(screenButton).WithId("Screen").AsSingle();
            Container.BindInstance(uiMenuView).AsSingle();
            Container.BindInterfacesAndSelfTo<UIMenuController>().AsSingle();
            
            Container.BindInstance(attentionPointView).AsSingle();
            Container.BindInstance(attentionPointHandlerSettings).AsSingle();
            Container.BindInterfacesAndSelfTo<AttentionPointController>().AsSingle();
            
        }
    }
}