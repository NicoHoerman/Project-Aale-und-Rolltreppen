using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.Contracts
{
    public interface IBoard
    {
        int size { get; set; }
        IPawn Pawn { get; set; }
        IEntity Entity { get; set; }
        List<IPawn> Pawns { get; set; }
        List<IEntity> Entities { get; set; }

    }
}
