using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.States
{
    public class GameStartingState : IState
    {
        private readonly IGame _game;
        private readonly ISourceWrapper _sourceWrapper;
        private bool _gameStarting;
        Parse parse = new Parse();
        private bool diceNotRolled = true;

        public GameStartingState(IGame game, ISourceWrapper sourceWrapper) 
        {
            _game = game;
            _sourceWrapper = sourceWrapper;
            _gameStarting = true;
        }

        public GameStartingState(IGame game)
            : this(game, new SourceWrapper())
        { }
        

        public void Execute()
        {
            _gameStarting = true;
            while (_gameStarting)
            {
                Console.Clear();
               _sourceWrapper.WriteOutput(parse.GameInfo());

               _sourceWrapper.WriteOutput(_game.InitializeGame());

               _sourceWrapper.WriteOutput(parse.AfterBoardInfo());

                while (diceNotRolled)
                {
                    var input = _sourceWrapper.ReadInput();
                    if (input == "/rolldice")
                    {
                        _gameStarting = false;
                        diceNotRolled = false;
                        _game.SwitchState(new GameRunningState(_game));
                    }
                    else parse.ChooseOutput(input);
                }
            }
        }
    }
}
