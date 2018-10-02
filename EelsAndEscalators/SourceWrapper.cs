using System;
using System.Collections.Generic;
using System.Text;
using EelsAndEscalators.Contracts;

//Nico
namespace EelsAndEscalators
{
    public class SourceWrapper : ISourceWrapper
    {
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
