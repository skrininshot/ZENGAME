using System;

namespace ZENGAME.Core
{
    public class StateFactory
    {
        public virtual State CreateState(int state)
        {
            throw new NotImplementedException();
        }
    }
}