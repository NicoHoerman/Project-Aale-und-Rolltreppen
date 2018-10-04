using EelsAndEscalators.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators
{
    public class Parse
    {
        public string currentPlayerInfo;
        public string diceResultInfo;
        private readonly ISourceWrapper _sourceWrapper;

        private Dictionary<string, Action> _commandList;
        private Action<string> _errorAction = s => { };

        public Parse(ISourceWrapper sourceWrapper)
        {
            _sourceWrapper = sourceWrapper;
            _commandList = new Dictionary<string, Action>();
        }

        public Parse()
        : this( new SourceWrapper())
        { }

        public void AddCommand(string token, Action command) => _commandList.Add(token, command);

        public void SetErrorAction(Action<string> action) => _errorAction = action;

        public void Execute(string token)
        {
            if (_commandList.TryGetValue(token.ToLower(), out var function) == false)
                _errorAction(token);
            else
                function();
        }


       

        public string MainMenuInfo()
        {
            return  "Welcome at Eels and Escalators" +"\n" +"You are in the MainMenu"+ "\n" +
                    "\n" + "Commandlist" + "\n" + "/startgame" + "\n" + "/closegame" + 
                    "\n" + "/classic" + "\n" + "/rolldice (only ingame)" + "\n" + "\n"  + "\n" + "First choose a ruleset then start the game" +
                    "\n" + "Waiting for your Input";
        }

        public string GameInfo()
        {
            return  "Game started" + "\n" + "Rules: Classic" + "\n" + "/help for Commands" +
                    "\n" + "\n" + "\n" + "Symbols:" + "\n" + "Player 1 is 1" + "\n" + "Player 2 is 2" + 
                    "\n" + "[ | _ | ] is field" + "\n" + "S Top of an Eel" + "\n" + "s Bottom of a Eel" +
                    "\n" + "E Top of an Escalator" + "\n" + "e Bottom of an Escalator" + "\n" + "\n";
        }



        public string AfterBoardInfo()
        {
            return currentPlayerInfo + "\n" + "Roll the Dice!";
        }

        public string GameFinshedInfo()
        {
            return "Game Finished" + "\n" + currentPlayerInfo + "Wins";
        }

        public string DiceResultInfo()
        {
            return "You rolled a"+ diceResultInfo;
        }
    }
}
