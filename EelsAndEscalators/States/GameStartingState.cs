using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.States
{
    public class GameStartingState : IState
    {
        private readonly IGame _game;
        public bool gameStarting;
        public GameStartingState(IGame game)
        {
            _game = game;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public string WaitingForInput()
        {
            throw new NotImplementedException();
        }
    }
}
