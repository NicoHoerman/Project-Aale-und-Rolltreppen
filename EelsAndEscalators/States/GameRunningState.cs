using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.States
{
    class GameRunningState : IState
    {
        private readonly IGame _game;
        public bool isRunning;
        public GameRunningState(IGame game)
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
