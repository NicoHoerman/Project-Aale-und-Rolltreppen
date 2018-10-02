using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.States
{
    class GameFinishedState : IState
    {
        private readonly IGame _game;
        public bool isFinished;
        public GameFinishedState(IGame game)
        {
            _game = game;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
