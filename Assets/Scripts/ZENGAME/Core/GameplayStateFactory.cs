using ModestTree;

namespace ZENGAME.Core
{
    public class GameplayStateFactory : StateFactory
    {
        readonly GameplayStateMenu.Factory _menuFactory;
        readonly GameplayStatePlay.Factory _playFactory;

        public GameplayStateFactory(
            GameplayStateMenu.Factory menuFactory,
            GameplayStatePlay.Factory playFactory)
        {
            _menuFactory = menuFactory;
            _playFactory = playFactory;
        }

        public override State CreateState(int state)
        {
            return state switch
            {
                (int)GameplayStates.Menu => _menuFactory.Create(),
                (int)GameplayStates.Play => _playFactory.Create(),
                _ => throw Assert.CreateException()
            };
        }
    }
    
    public enum GameplayStates
    {
        Menu,
        Play
    }

}