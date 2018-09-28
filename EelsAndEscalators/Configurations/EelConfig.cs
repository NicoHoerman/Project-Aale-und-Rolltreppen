using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.Configurations
{
    public class EelConfig
    {
        public int top_location;
        public int bottom_location;
        public int iD;
        

        public EelConfig(int top_location,int bottom_location,int iD)
        {
            this.top_location = top_location;
            this.bottom_location = bottom_location;
            this.iD = iD;
        }
    }
}
