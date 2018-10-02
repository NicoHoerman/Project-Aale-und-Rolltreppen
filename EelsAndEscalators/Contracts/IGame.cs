using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.Contracts
{
    public interface IGame
    {
         
        Logic  Logic { get; }
        IRules Rules { get; }
        IBoard Board { get; set; }
        IState State { get; }

        string InitializeGame();
        string CreateBoard();
        void SwitchRules(IRules creator);
        void SwitchState(IState newState);
    }
}
