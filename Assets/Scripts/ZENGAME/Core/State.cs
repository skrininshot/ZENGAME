using System;

namespace ZENGAME.Core
{
    public abstract class State : IDisposable
    {
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void Dispose() { }
    }
}