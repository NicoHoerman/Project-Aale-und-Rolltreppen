﻿using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;
using EelsAndEscalators.ClassicEandE;
using EelsAndEscalators.States;



namespace EelsAndEscalators
{
    public class Game : IGame
    {

        public IBoard Board { get; set; }
        public IRules Rules { get; }
        public IState State { get; private set; }
        public Logic Logic { get; }

        public IEntity Entity { get; set; }

        public IPawn pawn;

        List<IEntity> AllEels = new List<IEntity>();
              

        public Game(IBoard board, IRules rules)
        {
            Board = board;
            Rules = rules;
        }

        public Game()
        {

        }


        public void Init()
        {
            // Wichtige Objekte initialisiert
            // Configurationen ausgelesen.

            State = new MainMenuState(this);
        }

        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                State.Execute();
            }
        }

        public string CreateBoard()
        {
            /*

            var classicboard = Rules.CreateBoard();

            int fieldNumberInt = classicboard.size;
            string fieldNumber = "";
            string left = "[";
            string right = "] ";
            string pawn1space = "";
            string pawn2space = "";
            string topspace = "";
            string bottomspace = "";
            string board = "";
            string memory = "";

            for (int i = fieldNumberInt; i >= 1; i--) //Einen einzigen Kasten bauen?
            {
                
                //<Number>
                fieldNumber = fieldNumberInt.ToString();
                board += fieldNumber;
                memory = board;
                fieldNumberInt--;
                //</Number>

                //<Left>
                board = board + left;
                memory = board;
                //</left>

                //<top>


                Board.Entities.ForEach(if (Entity.type == EntityType.Eel)
                {
                    if (Entity.top_location == i)
                        topspace = "E";

                })
                
                
                
                    if (Entity.top_location == i)
                topspace = "E";

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
            foreach (pawns)
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


            */
            throw new NotImplementedException();
        }
        public string InitializeGame()
        {
           Rules.SetupEntitites();
            throw new NotImplementedException();
        }

        public void SwitchRules(IRules createdRule)
        {
            throw new NotImplementedException();
        }

        public void SwitchState(IState newState)
        {
            State = newState;
        }


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

