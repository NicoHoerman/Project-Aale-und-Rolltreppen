using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators
{
    class DataProvider
    {
        public string currentPlayerInfo;
        public string diceResultInfo;

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
