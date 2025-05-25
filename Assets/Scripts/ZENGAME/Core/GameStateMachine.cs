using Zenject;

namespace ZENGAME.Core
{
    public class GameStateMachine : StateMachine
    {
        public GameStateMachine(GameStateFactory factory)
        {
            _factory = factory;
        }
    }

    public class GameStateTransition : State
    {
        public class Factory : PlaceholderFactory<GameStateTransition> { }
    }
    
    public class GameStatePlay : State
    {
        public class Factory : PlaceholderFactory<GameStatePlay> { }
        
        public override void Start()
        {

        }

        public override void Dispose()
        {

        }
    }
    
    public enum GameStates
    {
        Transition,
        Play
    }

}