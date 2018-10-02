using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.ClassicEandE
{

    public class ClassicPawn : IPawn
    {
        public int location { get; set; }
        public int color { get; set; }
        public int playerID { get; set; }
        public long Id { get; set; }

        private readonly IGame _game;

        public ClassicPawn(IGame game)
        {
            _game = game;
        }

        public ClassicPawn()
        {

        }

        public void MovePawn()
        {
            try
            {
                location +=_game.Rules.diceResult;
            }
            catch
            {
                //may need a better Exception
                throw new Exception();
            }
        }
    }
}
