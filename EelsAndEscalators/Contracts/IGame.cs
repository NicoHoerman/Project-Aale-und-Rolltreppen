using EelsAndEscalators.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.Contracts
{
    public interface IGame
    {

        int winner { get; set; }

        IRules Rules { get; }
        IBoard Board { get; set; }
        IState State { get; }
        

        void InitializeGame();
        string CreateBoard();
        void SwitchRules(IRules creator);
        void SwitchState(IState newState);
        void ClosingGame();
    }
}
