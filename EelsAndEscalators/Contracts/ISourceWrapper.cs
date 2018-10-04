using System;
using System.Collections.Generic;
using System.Text;

namespace EelsAndEscalators.Contracts
{ 
    public interface ISourceWrapper
    {
        void WriteOutput(int x, int y, string output);
        string ReadInput();
        void Clear();
    }
}
