using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.ClassicEandE
{
    //Nico
    public class ClassicPawn : IPawn
    {
        public int location { get; set; }
        public int color { get; set; }
        public int playerID { get; set; }
        public long Id { get; set; }

        public ClassicPawn()
        {
        }

        public void MovePawn(int fieldsToMove)
        {
            location += fieldsToMove;
        }
    }
}
