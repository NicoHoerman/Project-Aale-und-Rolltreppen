using System;
using EelsAndEscalators.GameAndLogic;
using EelsAndEscalators;
using EelsAndEscalators.Test;

namespace Aale_und_Rolltreppen
{
    public class Program
    {
        static void Main(string[] args)
        {
            DBProvider test = new DBProvider();
            test.Test();

            var game = new Game();
            game.Init();
        }
    }
}
