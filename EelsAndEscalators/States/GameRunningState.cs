using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;


namespace EelsAndEscalators.States
{
    class GameRunningState : IState
    {
        private readonly IGame _game;
        private readonly ISourceWrapper _sourceWrapper;
        private readonly DataProvider _dataProvider;
        private readonly Logic _logic;

        public bool isRunning;
        private string _error = string.Empty;
        private string _gameInfoOutput = string.Empty;
        private string _boardOutput = string.Empty;
        private string _helpOutput = string.Empty;
        private string _lastInput = string.Empty;
        private string _afterTurnOutput = string.Empty;
        private string _afterBoardOutput = string.Empty;


        public GameRunningState(IGame game, ISourceWrapper sourceWrapper, DataProvider dataProvider, Logic logic)
        {
            _game = game;
            _sourceWrapper = sourceWrapper;
            _dataProvider = dataProvider;
            _logic = logic;
            isRunning = true;
        }

        public GameRunningState(IGame game)
            : this(game, new SourceWrapper(), new DataProvider(), new Logic(game))
        { }


        public void Execute()
        {
            var parser = new Parse();
            parser.AddCommand("/help", OnHelpCommand);
            parser.AddCommand("/closegame", OnCloseGameCommand);
            parser.AddCommand("/rolldice", OnRollDiceCommand);
            parser.SetErrorAction(OnErrorCommand);

            _gameInfoOutput = _dataProvider.GetText("gameinfo");
            _afterBoardOutput = string.Format(
                _dataProvider.GetText("afterboardinfo"), 
                _dataProvider.GetNumberLiteral(_logic.CurrentPlayerID));

            while (isRunning)
            {
                _boardOutput = _game.CreateBoard();
                UpdateOutput();
                _error = string.Empty;
                _helpOutput = string.Empty;
                _afterTurnOutput = string.Empty;

                _sourceWrapper.WriteOutput(0, 29, "Type an Command: ", ConsoleColor.DarkGray);
                Console.SetCursorPosition(17, 29);
                var input = _sourceWrapper.ReadInput();
                parser.Execute(input);

                _lastInput = input;
            }
        }

        private void OnErrorCommand(string token)
        {
            _error = "Unknown command.";
        }

        private void OnRollDiceCommand()
        {
            var turnstate = _logic.MakeTurn();
            ActOnTurnState(turnstate);   
        }

        private void OnCloseGameCommand()
        {
            _game.ClosingGame();
        }

        private void OnHelpCommand()
        {
            _helpOutput = "Commands are" + "\n" + "/closegame" + "\n" + "/rolldice";
        }

        private void UpdateOutput()
        {
            _sourceWrapper.Clear();
            //Game Info
            _sourceWrapper.WriteOutput(0, 0, _gameInfoOutput, ConsoleColor.DarkCyan);
            
            //Board Display
            _sourceWrapper.WriteOutput(0, 16, _boardOutput, ConsoleColor.Gray);
            
            //After Board Info 
            _sourceWrapper.WriteOutput(0, 23, _afterBoardOutput, ConsoleColor.DarkCyan);


            //After Turn Info
            if(_afterTurnOutput.Length != 0)
            _sourceWrapper.WriteOutput(0, 25, _afterTurnOutput, ConsoleColor.DarkCyan);


            //Help Info 
            if (_helpOutput.Length != 0)
                _sourceWrapper.WriteOutput(30, 2, _helpOutput, ConsoleColor.Yellow);


            //Last Input and Error
            if (_error.Length != 0)
            {
                _sourceWrapper.WriteOutput(0, 27, _lastInput, ConsoleColor.DarkRed);
                _sourceWrapper.WriteOutput(0, 28, _error, ConsoleColor.Red);
            }
        }

        //Undertakes diffrent Actions, depending on the TurnState returned by MakeTurn()
        public void ActOnTurnState(TurnState turnstate)
        {
            var dataprovider = new DataProvider();

            if (turnstate == TurnState.GameFinished)
            {
                _game.SwitchState(new GameFinishedState(_game));
            }
            else if (turnstate == TurnState.PlayerExceedsBoard)
            {
                _afterTurnOutput = string.Format(
                    dataprovider.GetText("playerexceedsboardinfo"), 
                    _dataProvider.GetNumberLiteral(_logic.CurrentPlayerID));

                turnstate = TurnState.TurnFinished;
            }
            else
            {
                _afterTurnOutput = string.Format(
                    dataprovider.GetText("diceresultinfo"),
                    _game.Rules.DiceResult);
            }
        }

    }
}
