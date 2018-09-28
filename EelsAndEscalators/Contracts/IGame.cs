using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.Contracts
{
    public interface IGame
    {
         
        Logic  Logic { get; }
        IRules Rules { get; }
        IBoard Board { get; }
        IState State { get; }

        string InitializeGame();
        string CreateBoard();
        void PawnCreation();
        void EntityCreation();

    }
}
