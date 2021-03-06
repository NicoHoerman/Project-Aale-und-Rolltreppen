﻿using System;
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
        public EntityType type => EntityType.Pawn;

        public ClassicPawn()
        {
        }

        public void MovePawn(int fieldsToMove)
        {
            location += fieldsToMove;
        }
    }
}
