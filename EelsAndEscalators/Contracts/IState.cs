using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.Contracts
{
    public interface IState
    {
<<<<<<< HEAD
        void Execute();  
=======
        bool Execute();
        void WaitingForInput();
>>>>>>> 49ec32429f67daa9bd2dc3429847650ee5c780aa
    }
}
