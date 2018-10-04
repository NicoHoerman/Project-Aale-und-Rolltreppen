using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators.ClassicEandE
{
    public class ClassicBoard : IBoard
    {
        public int size { get; } = 30;
        public List<IPawn> Pawns { get; set; }
        public List<IEntity> Entities { get; set; }

        public ClassicBoard()
        {
            List<IPawn> pawns = new List<IPawn>();
            List<IEntity> entities = new List<IEntity>();
        }

        
    }
}
