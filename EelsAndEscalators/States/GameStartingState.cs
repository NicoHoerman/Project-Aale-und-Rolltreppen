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
        private bool _diceNotRolled = true;
        private bool gameInitialized = false;
        private string _error = string.Empty;
        private string _lastInput = string.Empty;
        private string _helpOutput = string.Empty;

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
            var parser = new Parse();
            parser.AddCommand("/help", OnHelpCommand);
            parser.AddCommand("/closegame", OnCloseGameCommand);
            parser.AddCommand("/rolldice", OnRollDiceCommand);
            parser.SetErrorAction(OnErrorCommand);

            _gameStarting = true;
            while (_gameStarting)
            {
                while (_diceNotRolled)
                {
                    UpdateOutput();
                    _error = string.Empty;
                    _helpOutput = string.Empty;
                  
                    var input = _sourceWrapper.ReadInput();
                    parser.Execute(input);
                    _lastInput = input;
                }
            }
        }

        private void OnErrorCommand(string token)
        {
            _error = "Unknown command.";
        }

        private void OnRollDiceCommand()
        {
            _gameStarting = false;
            _diceNotRolled = false;
            _game.SwitchState(new GameRunningState(_game));
        }

        private void OnCloseGameCommand()
        {
            Environment.Exit(0);
        }

        private void OnHelpCommand()
        {
            _helpOutput = "Commands are" + "\n" + "/closegame" + "\n" + "/rolldice";
        }

        private void UpdateOutput()
        {
            _sourceWrapper.Clear();
            _sourceWrapper.WriteOutput(parse.GameInfo());
            if (!gameInitialized)
            {
                _sourceWrapper.WriteOutput(_game.InitializeGame());
                gameInitialized = true;
            }
            else _sourceWrapper.WriteOutput(_game.CreateBoard());

            _sourceWrapper.WriteOutput(parse.AfterBoardInfo());

            if (_helpOutput.Length != 0)
                _sourceWrapper.WriteOutput(_helpOutput);

            if (_error.Length != 0)
            {
                _sourceWrapper.WriteOutput(_lastInput);
                _sourceWrapper.WriteOutput(_error);
            }

        }
    }
}
