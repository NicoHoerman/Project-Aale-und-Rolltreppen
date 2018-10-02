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

        private IPawn CurrentPawn;
        public bool GameFinished;
        private int player = 1;
        private readonly IGame _game;
        public Logic(IGame game)
        {
            _game = game;
        }

        public IPawn GetPawn()
        {
            try
            {
                return _game.Board.Pawns[player];
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
            try
            {
                player = player == 1 ? 2 : 1;
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
                CurrentPawn = GetPawn();

                _game.Rules.RollDice();

                CurrentPawn.MovePawn();

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
            PlayerWins,
        }

        /*public TurnState GetTurnState()
        {
            throw new NotImplementedException();
        }*/
    }
}
