using EelsAndEscalators.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.States
{
    class GameEndingState :IState
    {
        private readonly IGame _game;

        public GameEndingState(IGame game)
        {
            _game = game;
        }

        public void Execute()
        {
            Environment.Exit(0);
        }
    }

}

