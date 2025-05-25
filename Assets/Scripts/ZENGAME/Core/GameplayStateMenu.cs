using UnityEngine;
using Zenject;

namespace ZENGAME.Core
{
    public class GameplayStateMenu : State
    {
        public class Factory : PlaceholderFactory<GameplayStateMenu> { }
        
        private readonly UIMenuController _uiMenuController;
        private readonly GameplayStateMachine _gameplayStateMachine;
        
        public GameplayStateMenu(UIMenuController uiMenuController,
            GameplayStateMachine gameplayStateMachine)
        {
            _uiMenuController = uiMenuController;
            _gameplayStateMachine = gameplayStateMachine;
        }

        public override void Start()
        {
            _uiMenuController.Show();
        }

        public override void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _gameplayStateMachine.ChangeState((int)GameplayStates.Play);
        }
        
        public override void Dispose()
        {
            _uiMenuController.Hide();
        }
    }
}