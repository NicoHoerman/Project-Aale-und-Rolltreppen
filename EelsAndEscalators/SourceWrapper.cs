using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;

namespace EelsAndEscalators
{
    public class SourceWrapper : ISourceWrapper
    {
        public void Clear()
        {
            Console.Clear();
        }

        public string ReadInput()
        {
            return Console.ReadLine();
        }

        public void WriteOutput(string output)
        {
            Console.WriteLine(output);
        }

    }
}
