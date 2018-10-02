using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aale_und_Rolltreppen;
using EelsAndEscalators;
using EelsAndEscalators.Contracts;
using EelsAndEscalators.States;

namespace Aale_und_Rolltreppen
{
    public class Program
    {

        static void Main(string[] args)
        {
            var game = new Game();
            game.Init();
        }
    }
}
