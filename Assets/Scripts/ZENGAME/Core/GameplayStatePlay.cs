using ZENGAME.Core.Installers;
using Zenject;

namespace ZENGAME.Core
{
    public class GameplayStatePlay : State
    {
        public class Factory : PlaceholderFactory<GameplayStatePlay> { }

        private readonly GameplayStateMachine _gameplayStateMachine;
        private readonly AttentionPointController _attentionPointController;
        private readonly PlayerScoreSystem _playerScoreSystem;
        
        private readonly Timer _timer;
        
        public GameplayStatePlay(AttentionPointController attentionPointController, 
            GameplayStateMachine gameplayStateMachine, PlayerScoreSystem playerScoreSystem)
        {
            _attentionPointController = attentionPointController;
            _gameplayStateMachine = gameplayStateMachine;
            _playerScoreSystem = playerScoreSystem;
            _timer = new Timer();
        }
        
        public override void Start()
        {
            _attentionPointController.Start();
            _attentionPointController.OnFinished += OnAttentionPointControllerFinished;
            _playerScoreSystem.SetCurrentScore(0);
            _timer.Start();
        }

        private void OnAttentionPointControllerFinished()
        {
            _playerScoreSystem.SetCurrentScore(_timer.PassedTime);
            _gameplayStateMachine.ChangeState((int)GameplayStates.Menu);
        }

        public override void Dispose()
        {
            _attentionPointController.Dispose();
            _attentionPointController.OnFinished -= OnAttentionPointControllerFinished;
        }
    }
}