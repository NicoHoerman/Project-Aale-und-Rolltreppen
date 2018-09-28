using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.Configurations
{
    public class PawnConfig
    {
        public int location;
        public int color;
        public int playerID;
        public int iD;

        public PawnConfig( int location, int color, int playerID, int iD)
        {
            this.location = location;
            this.color = color;
            this.playerID = playerID;
            this.iD = iD;
        }

        public PawnConfig()
        {

        }
    }
}
