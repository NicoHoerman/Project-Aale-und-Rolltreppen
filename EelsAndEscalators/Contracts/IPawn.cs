using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.Contracts
{
    //Nico
    public interface IPawn
    {
        int location { get; set; }
        int color { get; set; }
        int playerID { get; set; }
        void MovePawn();
    }
}
