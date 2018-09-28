using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.Contracts
{
    interface ISourceWrapper
    {
        void WriteOutput(string output);
        string ReadInput();
    }
}
