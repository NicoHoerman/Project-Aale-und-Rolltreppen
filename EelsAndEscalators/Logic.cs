using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;
using EelsAndEscalators.ClassicEandE;
using EelsAndEscalators.States;




namespace EelsAndEscalators
{

    public class Logic
    {

        GameRunningState gameRunningState { get; set; }
        GameFinishedState gameFinishedState { get; set; }
        

        private IPawn CurrentPawn;
        public bool GameFinished;
        private int playerID = 1;

      
        private readonly IGame _game;
        public Logic(IGame game)
        {
            _game = game;
        }

        //Gets the Pawn with the matching playerID from the Pawns List
        public IPawn GetPawn()
        {
            try
            {
                return CurrentPawn =  _game.Board.Pawns[playerID];
            }
            catch
            {
                throw new Exception();
            }

        }


        public TurnState CheckIfGameFinished()
        {
            try
            {
                GameFinished = CurrentPawn.location == _game.Board.size ? true : false;
                return GameFinished == true ? TurnState.GameFinished : TurnState.TurnFinished;
            }
            catch
            {
                throw new Exception();
            }

        }


        public void NextPlayer()
        {
            //if its player 1's turn, switch int player to 2. If not, switch it to 1.
            try
            {
                playerID = playerID == 1 ? 2 : 1;
            }

            catch
            {
                throw new Exception();
            }
        }


        public TurnState MakeTurn()
        {
            try
            {
                GetPawn();

                _game.Rules.RollDice();

                //Check If Player Exceeds Board
                if (CurrentPawn.location + _game.Rules.diceResult > _game.Board.size)
                    return TurnState.PlayerExceedsBoard;
                else CurrentPawn.MovePawn();
                
                //Entities check if the pawn is on them
                _game.Board.Entities.ForEach(entity =>
                {
                    if (entity.OnSamePositionAs())
                    { entity.SetPawn(); }
                });

                
                NextPlayer();

                return CheckIfGameFinished();

            }
            catch
            {
                throw new Exception();
            }

        }

        public enum TurnState
        {
            TurnFinished,
            PlayerExceedsBoard,
            GameFinished,
        }

        //Undertakes diffrent Actions, depending on the TurnState returned by MakeTurn()
        public void ActOnTurnState(TurnState currentTurnState)
        {
            currentTurnState = MakeTurn();

            if (currentTurnState == TurnState.GameFinished)
            {
                gameFinishedState.Execute();
                gameRunningState.isRunning = false;
            }
            else if (currentTurnState == TurnState.PlayerExceedsBoard)
            {
                gameRunningState.AfterTurnMessage();
                currentTurnState = TurnState.TurnFinished;
            }
            else
            {
                gameRunningState.AfterTurnMessage();
                
            }    

        }

        

        
    }
}
