using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EelsAndEscalators;
using EelsAndEscalators.Contracts;
using EelsAndEscalators.States;
using EelsAndEscalators.ClassicEandE;

namespace UnitTestAuR
{
    [TestClass]
    public class GameRunningState_Test
    {
        //Attributes
        private Func<GameRunningState> Creator;
        DataProvider dataProvider = new DataProvider();

        private int counter = 0;
        private bool _switchStateMethodCalled = false;
        private bool _closingGameMethodCalled = false;
        private string _testOutput;
        private IRules _ruleUnderTest;
        private Logic logic;

        List<string> commands;
        List<string> outputs = new List<string>();

        private string Test(int x, int y, string z, ConsoleColor c)
        {
            return z;
        }

       

        [TestInitialize]
        public void Setup()
        {
            //Defaults
            _testOutput = "Invalid input";

            //Mocked SourceWrapper
            var mockedSourceWrapper = new Mock<ISourceWrapper>();
            mockedSourceWrapper.Setup(s => s.WriteOutput(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<ConsoleColor>()))
                .Callback<int, int, string, ConsoleColor>((x, y, z, s) => outputs.Add(z));
            mockedSourceWrapper.Setup(s => s.ReadInput())
               .Returns(() => commands[counter])
               .Callback(() => counter++);

           



            //Parser und DataProvider sind implementierte Klassen

            //Mock Game
            var mockedGame = new Mock<IGame>();
            mockedGame.Setup(g => g.SwitchRules(_ruleUnderTest))
                .Callback(() => _ruleUnderTest = new ClassicRules(mockedGame.Object));
            mockedGame.Setup(g => g.SwitchState(It.IsAny<IState>()))
                .Callback(() => _switchStateMethodCalled = true);
            mockedGame.Setup(g => g.ClosingGame())
                .Callback(() => Environment.Exit(0));
            mockedGame.Setup(g => g.Board.CreateOutput())
                .Returns(() => "");
            mockedGame.Setup(g => g.Init())
                .Callback(() => Environment.Exit(0));
            


            logic = new Logic(mockedGame.Object);

            //logic.MakeTurn();

            Creator = () => new GameRunningState(mockedGame.Object, mockedSourceWrapper.Object,
                                                    dataProvider, logic);
        }


        [TestMethod]
        // /closegame closes the game 
        public void If_Calling_Execute__and_command_is_rolldice_game_should_be_finished()
        {
            commands = new List<string>();
            commands.Add("/rolldice");
            commands.Add("/closegame");

            var state = Creator();
            state.Execute();

           // Assert Logic Make Turn and Act on turn wurden aufgerufen
        }

        [TestMethod]
        // /help  
        public void If_Calling_Execute__and_command_is_help_HelpMessage_should_be_returned()
        {
            commands = new List<string>();
            commands.Add("/help");
            commands.Add("/closegame");
            _testOutput = "Commands are" + "\n" + "/closegame" + "\n" + "/rolldice";

            var state = Creator();
            state.Execute();

            Assert.IsTrue(outputs.Contains(_testOutput));
        }

       


    }
}
