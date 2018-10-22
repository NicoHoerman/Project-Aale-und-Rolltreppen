using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.States
{
    class GameFinishedState : IState
    {
        private readonly IGame _game;
        private readonly ISourceWrapper _sourceWrapper;
        private readonly DataProvider _dataProvider;
        private readonly Logic _logic;

        public bool isFinished;
        private string _finishinfo =string.Empty;
        private string _finishskull1 = string.Empty;
        private string _finishskull2 = string.Empty;
        private int _winner;

        public GameFinishedState(IGame game, ISourceWrapper sourceWrapper, DataProvider dataProvider, Logic logic, int winner)
        {
            _game = game;
            _sourceWrapper = sourceWrapper;
            _dataProvider = dataProvider;
            _logic = logic;
            isFinished = true;
            _winner = winner;
        }

        public GameFinishedState(IGame game,int winner)
            : this(game, new SourceWrapper(), new DataProvider(),new Logic(game),winner)
        { }

        public void Execute()
        {
            _finishinfo = string.Format(
                _dataProvider.GetText("playerwins"),
                _dataProvider.GetNumberLiteral(_winner));
            _finishskull1 = string.Format(
                _dataProvider.GetText("finishskull1"));
            _finishskull2 = string.Format(
                _dataProvider.GetText("finishskull2"));

            while (isFinished)
            {
                _sourceWrapper.Clear();
                _sourceWrapper.WriteOutput(35, 0, _finishinfo, ConsoleColor.Green);
                _sourceWrapper.WriteOutput(0, 0, _finishskull1);
                _sourceWrapper.WriteOutput(35, 5, _finishskull2);
                _sourceWrapper.WriteOutput(73, 0, _finishskull1);

                _sourceWrapper.WriteOutput(35, 3, "Press any Key to leave", ConsoleColor.DarkGreen);
                Console.SetCursorPosition(35, 15);
                var input = _sourceWrapper.ReadKey();
                 if(input != null)
                {
                    isFinished = false;
                    _game.SwitchState(new MainMenuState(_game));
                }

                

            }
        }

    }
}
