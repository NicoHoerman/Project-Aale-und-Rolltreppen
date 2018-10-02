using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.Contracts
{
    //Nico
    public enum EntityType
    {
        Eel,
        Escalator
    }
    
    public interface IEntity
    {
        int top_location { get; set; }
        int bottom_location{ get; set; }
        EntityType type { get; }

        void SetPawn();
        bool OnSamePositionAs();
    }
}
