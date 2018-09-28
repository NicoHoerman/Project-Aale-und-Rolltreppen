using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Configurations;
using EelsAndEscalators.Contracts;
using EelsAndEscalators.ClassicEandE;




namespace EelsAndEscalators
{

    public class Logic 
    {
        private readonly IGame _game;
        public bool gameFinished;
        private int player = 1;

        public Logic(IGame game)
        {
            _game = game;
        }
       
        public bool CheckIfGameFinished()
        {
            throw new NotImplementedException();
        }

        public IPawn GetPawn()
        {
            throw new NotImplementedException();
        }

        public void NextPlayer()
        {
            throw new NotImplementedException();
        }
        

        public bool MakeTurn(int dice_result)
        {
            throw new NotImplementedException();
        }

        public enum TurnState
        {
            TurnFinished,
            PlayerExceedsBoard,
            GameFinished,
            PlayerWins,
        }

        public TurnState GetTurnState()
        {
            throw new NotImplementedException();
        }
    }
}
