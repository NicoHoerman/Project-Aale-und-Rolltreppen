using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.Contracts
{
    //Nico
    public interface ISourceWrapper
    {
        void WriteOutput(string output);
        string ReadInput();
    }
}
