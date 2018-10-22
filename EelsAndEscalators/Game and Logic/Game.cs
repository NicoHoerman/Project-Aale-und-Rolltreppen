using System;
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
        public IRules Rules { get; private set; }
        public IState State { get; private set; }

        public void Init()
        {
            // Wichtige Objekte initialisiert
            // Configurationen ausgelesen.

            State = new MainMenuState(this);
            Run();
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

            try
            {
                var classicboard = Rules.CreateBoard();

                int fieldNumberInt = classicboard.size;
                string fieldNumber = string.Empty;
                string left = "[";
                string right = "] ";
                string pawn1space = string.Empty;
                string pawn2space = string.Empty;
                string topspace = string.Empty;
                string bottomspace = string.Empty;
                string board = string.Empty;
                string memory = string.Empty;

                for (int i = fieldNumberInt; i >= 1; i--) //Methoden Inhalt: Einen Kasten bauen.
                {

                    //<Number>
                    //fieldNumber = string.Empty;

                    fieldNumber = fieldNumberInt.ToString();

                    if (fieldNumber.Length == 2)
                        fieldNumber = " " + fieldNumber;
                    else if (fieldNumber.Length == 1)
                        fieldNumber = "  " + fieldNumber;
                        
                    board += fieldNumber;
                    memory = board;
                    //</Number>

                    //<Left>
                    board = board + left;
                    memory = board;
                    //</left>

                    //<topspace>
                    Board.Entities.ForEach(entity =>
                    {
                        if (entity.type == EntityType.Eel & entity.top_location == i)
                            topspace = "S";
                        else if (entity.type == EntityType.Escalator & entity.top_location == i)
                            topspace = "E";
                       

                    });

                    if(topspace.Length == 0)
                        topspace = " ";
                    
                    board = board + topspace;
                    topspace = string.Empty;
                    memory = board;
                    //</topspace>

                    //<DivideSpae>
                    board = board + "|";
                    memory = board;
                    //<DivideSpace

                    //<pawnspace>
                    Board.Pawns.ForEach(pawn =>
                    {
                        if (pawn.location == i & pawn1space.Length == 0)
                            pawn1space = pawn.playerID.ToString();
                        else if (pawn.location == i & pawn2space.Length == 0  )
                            pawn2space = pawn.playerID.ToString();
                       

                    });

                    if (pawn1space.Length == 0)
                        pawn1space = " "; 

                    if (pawn2space.Length == 0)
                        pawn2space = " ";



                    board = board + pawn1space + "," + pawn2space;
                    pawn1space = pawn2space = string.Empty;
                    memory = board;
                    //</pawnspace>

                    //<DivideSpae>
                    board = board + "|";
                    memory = board;
                    //<DivideSpace

                    //<bot>
                    Board.Entities.ForEach(entity =>
                    {
                        if (entity.type == EntityType.Eel & entity.bottom_location == i)
                            bottomspace = "s";
                        else if (entity.type == EntityType.Escalator & entity.bottom_location == i)
                            bottomspace = "e";
                         
                    });
                    if(bottomspace.Length == 0)
                        bottomspace = " ";



                    board = board + bottomspace;
                    bottomspace = string.Empty;
                    memory = board;
                    //</bot>

                    //<Right>
                    board = board + right;
                    memory = board;
                    //</Right>
                    if (fieldNumber == " 26")
                        board = board + "\n";
                    else if (fieldNumber == " 21")
                        board = board + "\n";
                    else if (fieldNumber == " 16")
                        board = board + "\n";
                    else if (fieldNumber == " 11")
                        board = board + "\n";
                    else if (fieldNumber == "  6")
                        board = board + "\n";




                    fieldNumberInt--;

                }
                return memory;
            }
            catch
            {
                throw new Exception();
            }
        }
        public void InitializeGame()
        {
           Rules.SetupEntitites();
        }
        public void SwitchRules(IRules createdRule)
        {
             Rules = createdRule;     
        }       

        public void SwitchState(IState newState)
        {
            State = newState;
        }

        public void ClosingGame()
        {
            Environment.Exit(0);
        }

    }

}   
