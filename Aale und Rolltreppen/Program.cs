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

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.
            MethodBase.GetCurrentMethod().DeclaringType);


        static void Main(string[] args)
        {
            

            var game = new Game();
            game.Init();

            log.Info("Hello logging world!");
            log.Info("xoxoxoxoxoxoxoxoxoxo");

        }
    }
}
