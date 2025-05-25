using Zenject;

namespace ZENGAME.Core
{
    public class GameStateTransition : State
    {
        public class Factory : PlaceholderFactory<GameStateTransition> { }
    }
}