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
        private string _testOutput;
        private int playerIDUnderTest;
        private int locationUnderTest;
        private int sizeUnderTest;
        private int diceResultUndertest;
        private IRules _ruleUnderTest;
        private Logic logic;
        private TurnState turnStateUnderTest;

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
            playerIDUnderTest = 2;
            locationUnderTest = 1;
            sizeUnderTest = 3;
            diceResultUndertest = 1;
            turnStateUnderTest = TurnState.TurnFinished;

            //Mocked SourceWrapper
            var mockedSourceWrapper = new Mock<ISourceWrapper>();
            mockedSourceWrapper.Setup(s => s.WriteOutput(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<ConsoleColor>()))
                .Callback<int, int, string, ConsoleColor>((x, y, z, s) => outputs.Add(z));
            mockedSourceWrapper.Setup(s => s.ReadInput())
               .Returns(() => commands[counter])
               .Callback(() => counter++);

            //Mock Board
            var mockedBoard = new Mock<IBoard>();
            mockedBoard.Setup(b => b.size)
                .Returns(() => sizeUnderTest);

            //Mock Pawn
            var mockedPawn = new Mock<IPawn>();
            mockedPawn.Setup(p => p.playerID)
                .Returns(() =>playerIDUnderTest);
            mockedPawn.Setup(p => p.location)
                .Returns(() => locationUnderTest);

            //Parser und DataProvider sind implementierte Klassen

            //Mock Game
            var mockedGame = new Mock<IGame>();
            mockedGame.Setup(g => g.SwitchRules(_ruleUnderTest))
                .Callback(() => _ruleUnderTest = new ClassicRules(mockedGame.Object));
            mockedGame.Setup(g => g.Board.CreateOutput())
                .Returns(() => "");
            mockedGame.Setup(g => g.Rules.DiceResult)
                .Returns(() => diceResultUndertest);

            
            
                
            logic = new Logic(mockedGame.Object);

            logic.CurrentPlayerID = 2;

            Creator = () => new GameRunningState(mockedGame.Object, mockedSourceWrapper.Object,
                                                    dataProvider, logic);
        }


        [TestMethod]
        // /closegame closes the game 
        public void If_Calling_ActOnTurn__and_Turnstate_is_Turnfinished()
        {
           
            _testOutput = "Player One rolled a 1";

            var state = Creator();

            state.ActOnTurnState(turnStateUnderTest);          
            
            Assert.AreEqual(_testOutput, state._afterTurnOutput);
        }

        [TestMethod]
        // /closegame closes the game 
        public void If_Calling_ActOnTurn__and_Turnstate_is_PlayerExceeds()
        {
            turnStateUnderTest = TurnState.PlayerExceedsBoard;
            diceResultUndertest = 5;

            _testOutput = "Player One rolled a 5\n" + "Your role was too high\n"+"Better Luck next time";

            var state = Creator();

            state.ActOnTurnState(turnStateUnderTest);

            Assert.AreEqual(_testOutput, state._afterTurnOutput);
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



                /*mockedGame.Setup(g => g.SwitchState(It.IsAny<IState>()))
                .Callback(() => _switchStateMethodCalled = true);*/
