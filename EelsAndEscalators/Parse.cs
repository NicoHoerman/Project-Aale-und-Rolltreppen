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

        public Parse(ISourceWrapper sourceWrapper)
        {
            _sourceWrapper = sourceWrapper;
        }
        public Parse()
        : this( new SourceWrapper())
        { }


      
        public void WriteAt(string text,int y)
        {
            Console.SetCursorPosition(0, y);
            _sourceWrapper.WriteOutput(text);
        }

        public void ChooseOutput(string input)
        {
            if (input == "/help")
                _sourceWrapper.WriteOutput(HelpInfo());
            else if(input == "/closegame")
                Environment.Exit(0);
            else _sourceWrapper.WriteOutput("Use an active command");
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


        public string HelpInfo()
        {
            return "Commands are" +"\n" + "/closegame" + "\n" + "/rolldice";
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
