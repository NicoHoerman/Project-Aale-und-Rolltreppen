using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.Contracts
{
   public interface IState
    {
        bool Execute();
        void WaitingForInput();
    }
}
