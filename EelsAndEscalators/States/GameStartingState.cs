using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.States
{
    //Nico
    public class GameStartingState : IState
    {
        private readonly IGame _game;
        private bool _gameStarting;

        public GameStartingState(IGame game)
        {
            _game = game;
            _gameStarting = true;
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
