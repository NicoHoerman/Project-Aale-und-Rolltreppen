using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.Contracts
{
    public interface IBoard
    {
        int size { get; set; }

        List<IPawn> Pawns { get; set; }
        List<IEntity> Entities { get; set; }

    }
}
