﻿using System;
using System.Collections.Generic;
using System.Text;
<<<<<<< HEAD
=======

>>>>>>> 49ec32429f67daa9bd2dc3429847650ee5c780aa
using EelsAndEscalators.Contracts;
using EelsAndEscalators.ClassicEandE;
using EelsAndEscalators.States;



namespace EelsAndEscalators
{
    public class Game : IGame
    {

        public IBoard Board { get; set; }
        public IRules Rules { get; }
<<<<<<< HEAD
        public IState State { get; private set; }
=======
        public IState State { get; set; }       
>>>>>>> 49ec32429f67daa9bd2dc3429847650ee5c780aa
        public Logic Logic { get; }
        public IPawn Pawn { get; }

        public IEntity Entity { get; set; }
      
        List<IEntity> AllEels = new List<IEntity>();

<<<<<<< HEAD
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
=======
        private IRules currentRule;
>>>>>>> 49ec32429f67daa9bd2dc3429847650ee5c780aa

     
        public string CreateBoard()
        {

            try
            {
                var classicboard = currentRule.CreateBoard();

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

                for (int i = fieldNumberInt; i >= 1; i--) //Methoden Inhalt: Einen Kasten bauen.
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

                    //<topspace>
                    Board.Entities.ForEach(entity =>
                    {
                        if (Entity.type == EntityType.Eel & Entity.top_location == i)
                            topspace = "S";
                        else if (Entity.type == EntityType.Escalator & Entity.top_location == i)
                            topspace = "E";
                        else topspace = " ";

                    });

                    board = board + topspace;
                    memory = board;
                    //</topspace>

                    //<pawnspace>
                    Board.Pawns.ForEach(pawn =>
                    {
                        if (Pawn.location == i & pawn1space.Length == 0)
                            pawn1space = "|" + Pawn.playerID.ToString();
                        else if (Pawn.location == i & pawn2space.Length == 0  )
                            pawn2space = Pawn.playerID.ToString() + "|";
                        else pawn1space = " "; pawn2space = " ";
                        

                    });

                    if (pawn2space.Length == 0)
                        pawn2space = " ";



                    board = board + pawn1space + pawn2space;
                    board = memory;
                    //</pawnspace>

                    //<bot>
                    Board.Entities.ForEach(entity =>
                    {
                        if (Entity.type == EntityType.Eel & Entity.bottom_location == i)
                            bottomspace = "s";
                        else if (Entity.type == EntityType.Escalator & Entity.bottom_location == i)
                            bottomspace = "e";
                        else bottomspace = " ";


                    });

                    board = board + bottomspace;
                    memory = board;
                    //</bot>

                    //<Right>
                    board = board + right;
                    memory = board;
                    //</Right>


                }
                return memory;
            }
            catch
            {
                throw new Exception();
            }
        }
        public string InitializeGame()
        {
           currentRule.SetupEntitites();
            return CreateBoard();  
        }
        public void SwitchRules(IRules createdRule)
        {
             currentRule = createdRule;     
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

