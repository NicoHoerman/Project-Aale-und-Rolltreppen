using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.ClassicEandE
{
    public class ClassicBoard : IBoard
    {
        public int size { get => size; set => size = 30; }
        public List<IPawn> Pawns { get; set; }
        public List<IEntity> Entities { get; set; }

        
    }
}
