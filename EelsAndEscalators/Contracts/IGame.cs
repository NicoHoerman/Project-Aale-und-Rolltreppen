﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.Contracts
{
    public interface IGame
    {
         
       
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
