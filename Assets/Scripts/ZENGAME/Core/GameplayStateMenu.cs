using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ZENGAME.Core
{
    public class GameplayStateMenu : State
    {
        public class Factory : PlaceholderFactory<GameplayStateMenu> { }
        
        private readonly UIMenuController _uiMenuController;
        private readonly Button _button;
        private readonly GameplayStateMachine _gameplayStateMachine;
        
        public GameplayStateMenu(UIMenuController uiMenuController,
            [Inject(Id="Screen")] Button button,
            GameplayStateMachine gameplayStateMachine)
        {
            _uiMenuController = uiMenuController;
            _button = button;
            _gameplayStateMachine = gameplayStateMachine;
        }

        public override void Start()
        {
            _uiMenuController.Show();
            _button.onClick.AddListener(OnClick);
        }
        
        private void OnClick()
        {
            _gameplayStateMachine.ChangeState((int)GameplayStates.Play);
        }
        
        public override void Dispose()
        {
            _uiMenuController.Hide();
            _button.onClick.RemoveListener(OnClick);
        }
    }
}