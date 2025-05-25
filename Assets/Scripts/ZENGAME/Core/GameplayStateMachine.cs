namespace ZENGAME.Core
{
    public class GameplayStateMachine : StateMachine
    {
        public GameplayStateMachine(GameplayStateFactory factory)
        {
            _factory = factory;
        }
        
        public override void Initialize()
        {
            ChangeState((int)GameplayStates.Menu);
        }
    }
}