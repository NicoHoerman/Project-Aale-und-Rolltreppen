using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Configurations;
using EelsAndEscalators.Contracts;
using EelsAndEscalators.ClassicEandE;



namespace EelsAndEscalators
{
    public class Game : IGame
    {
        
        public IBoard Board { get; }
        public IRules Rules { get; }
        public IState State { get; set; }
        public Logic Logic { get; }

        public Game(IBoard board, IRules rules)
        {
            Board = board;
            Rules = rules;
        }

        public void ChooseRules(int rules_set)
        {
            throw new NotImplementedException();
        }

        public void EntityCreation()
        {
            throw new NotImplementedException();
        }

        public void PawnCreation()
        {

            throw new NotImplementedException();
        }

        public string CreateBoard()
        {
           /* ClassicRules classicrules = new ClassicRules();
            var classicboard = classicrules.CreateBoard();
            int fieldNumberInt = classicboard.board_size;
            string fieldNumber = "";
            string left = "[";
            string right = "] ";
            string pawn1space = "";
            string pawn2space = "";
            string topspace = "";
            string bottomspace = "";
            string board = "";
            string memory ="";

            for (int i = classicboard.board_size; i >= 1; i--)
            {
                //<Number>
                fieldNumber = fieldNumberInt.ToString();
                board = board + fieldNumber;
                memory = board;
                fieldNumberInt--;
                //</Number>

                //<Left>
                board = board + left;
                memory = board;
                //</left>

                //<top>
                foreach (entities)
                {
                    if(toplocation = i)
                       choose E S
                    topspace = "S";
                }
                board = board + topspace;
                memory = board;
                //</top>

                //<pawn1space>
                foreach (pawns)
                {
                    if (pawn.location = i)
                        pawn1space = "1";
                }
                board = board + pawn1space;
                board = memory;
                //</pawn1space>

                //<pawn2space>
                foreach(pawns)
                if (pawnlocation = i)
                    pawn2space = "2";
                board = board + pawn2space;
                board = memory;
                //</pawn2space>

                //<bot>
                foreach (entities)
                {
                    if (botlocation = i)
                        choose e s
                     topspace = "e";
                }
                board = board + bottomspace;
                memory = board;
                //</bot>

                //<Right>
                board = board + right;
                memory = board;
                //</Right>
            }




            */

            throw new NotImplementedException();
        }

        public string InitializeGame()
        {
            throw new NotImplementedException();
        }

    }


/*
    class MenuState
    {
        private Dictionary<string, Func<IGame, IRules>> _rulesFactory = new Dictionary<string, Func<IGame, IRules>>
        {
            { "classic", (game) => new ClassicRules(game) },
        //    { "fancy", (g) => new FancyRules(g) },
        };

        private IGame _game;

        public MenuState(IGame game)
        {
            _game = game;
        }

        public void Execute()
        {
            while(true)
            {
                ShowMenu();
                var input = WaitForInput();
                var parsedcommand = Parse(command);
                if (parsedcommand.command == "switchrules")
                    CreateNewRulesInGame(parsedcommand.parameterlist[0]);
            }
        }

        private object Parse(string command)
        {
            throw new NotImplementedException();
        }

        private object WaitForInput()
        {
            throw new NotImplementedException();
        }

        private void ShowMenu()
        {
            throw new NotImplementedException();
        }

        private void CreateNewRulesInGame(string rulesname)
        {
            //if (rulesname == "classic")
            //    _game.SwitchRules(new ClassicRules(_game));
            //else if (rulesname == "fancy")
            //    _game.SwitchRules(new FancyRules(_game));
            //else GiveErrorRuleNotFound();

            if (_rulesFactory.TryGetValue(rulesname, out var creator))
                _game.SwitchRules(creator(_game));
            else
                GiveErrorRuleNotFound();
        }

        private void GiveErrorRuleNotFound()
        {
            throw new NotImplementedException();
        }
    }
    

    public enum TurnState
    {
        Ok,
        PlayerExceedsBoard,
        PlayerMustWait,
        PlayerWins,
    }
    public void MakeTurn(int dice) { ...}
    public TurnState GetTurnState() { ...}
    */
}

