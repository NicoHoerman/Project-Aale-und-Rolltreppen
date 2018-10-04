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

        public void WriteOutput(int x, int y, string output)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(output);
        }

    }
}
