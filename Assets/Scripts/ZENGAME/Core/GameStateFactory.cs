using ModestTree;

namespace ZENGAME.Core
{
    public class GameStateFactory : StateFactory
    {
        readonly GameStateTransition.Factory _transitionFactory;
        readonly GameStatePlay.Factory _playFactory;

        public GameStateFactory(
            GameStateTransition.Factory transitionFactory,
            GameStatePlay.Factory playFactory)
        {
            _transitionFactory = transitionFactory;
            _playFactory = playFactory;
        }

        public override State CreateState(int state)
        {
            return state switch
            {
                (int)GameStates.Transition => _transitionFactory.Create(),
                (int)GameStates.Play => _playFactory.Create(),
                _ => throw Assert.CreateException()
            };
        }
    }
    
    public enum GameStates
    {
        Transition,
        Play
    }
}