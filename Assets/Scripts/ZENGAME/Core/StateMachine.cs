using System;
using ZENGAME.Core;
using Zenject;

public abstract class StateMachine : IInitializable, ITickable, IDisposable
{
    public Action<State> OnStateChange;
    public State CurrentState => _currentState;
    protected State _currentState;
    protected StateFactory _factory;

    public virtual void Initialize() { }

    public virtual void Tick() { _currentState?.Update(); }

    public virtual void Dispose() => _currentState?.Dispose();

    public virtual void ChangeState(int state)
    {
        _currentState?.Dispose();
        _currentState = _factory.CreateState(state);
        _currentState.Start();
        OnStateChange?.Invoke(_currentState);
    }
}