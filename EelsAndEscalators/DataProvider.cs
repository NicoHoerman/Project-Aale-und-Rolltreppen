﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators
{
    public class DataProvider
    {
        private Dictionary<string, string> _text = new Dictionary<string, string>
        {
            {
                "mainmenuinfo",
                "Welcome at Eels and Escalators\n" +
                "You are in the MainMenu\n\nCommandlist\n"+
                "/startgame\n" +
                "/closegame\n" +
                "/classic\n" +
                "/rolldice (only ingame)\n" +
                "\n" +
                "\n" +
                "First choose a ruleset then start the game"
            },
            {
                "gameinfo",
                "Game started\n" +
                "Rules: Classic\n" +
                "/help for Commands\n" +
                "\n" +
                "\n" +
                "Symbols:\n" +
                "Player 1 is 1\n" +
                "Player 2 is 2\n" +
                "[ | _ | ] is field\n" +
                "S Top of an Eel\n" +
                "s Bottom of a Eel\n" +
                "E Top of an Escalator\n" +
                "e Bottom of an Escalator"
            },
            {
                "afterboardinfo",
                "{0} \n" +
                "Roll the dice!"
            },
            {
                "gamefinishedinfo",
                "Game finished\n"+
                "{0} wins!"
            },
            {
                "diceresultinfo",
                "You rolled a {0}"
            },
            {
                "playerexceedsboardinfo",
                "You rolled to much\n"+
                "One Turn off"
            }

        };

        public string GetText(string key) => _text[key];
    }
}
