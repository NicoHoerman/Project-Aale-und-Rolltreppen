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
        public bool gameStarting;
        public GameStartingState(IGame game)
        {
            _game = game;
        }

        public bool palyerOneTurn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Execute()
        {
            throw new NotImplementedException();
        }

        public void WaitingForInput()
        {
            throw new NotImplementedException();
        }
    }
}
