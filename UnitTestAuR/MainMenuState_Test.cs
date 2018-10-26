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
    /// <summary>
    /// Test for MainMenuState 
    /// </summary>
    [TestClass]
    public class MainMenuState_Test
    {
        //Attributes
        private Func<MainMenuState> Creator;
        DataProvider dataProvider = new DataProvider();

        private int counter = 0;
        private bool _switchStateMethodCalled = false;
        private bool _closingGameMethodCalled = false;
        private string _testOutput;
        private IRules _ruleUnderTest;

        List<string> commands;
        List<string> outputs = new List<string>();

        private string Test(int x,int y,string z,ConsoleColor c)
        {
            return z;
        }

      

        [TestInitialize]
        public void Setup()
        {
            //Defaults
            //_input = "test";
            _testOutput = "Invalid input";


            //Mocked Configurationprovider
            var mockedConfigProvider = new Mock<IConfigurationProvider>();
            //mockedConfigProvider.Setup(c => c.)
            

            //Mocked SourceWrapper
            var mockedSourceWrapper = new Mock<ISourceWrapper>();
            mockedSourceWrapper.Setup(s => s.WriteOutput(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<ConsoleColor>()))
                .Callback<int,int,string,ConsoleColor>((x,y,z,s)=> outputs.Add(z));
            mockedSourceWrapper.Setup(s => s.ReadInput())
               .Returns(() => commands[counter] )
               .Callback(() => counter++);

            //sourcewrapper.Clear soll nichts machen
            //sourcewrapper.ReadKey wird nicht aufgerufen 

            //Parser und DataProvider sind implementierte Klassen





            //Mock Game
            var mockedGame = new Mock<IGame>();
            mockedGame.Setup(g => g.SwitchRules(_ruleUnderTest))
                .Callback(() => _ruleUnderTest = new ClassicRules(mockedGame.Object));
            mockedGame.Setup(g => g.SwitchState(It.IsAny<IState>()))
                .Callback(() => _switchStateMethodCalled = true);
            mockedGame.Setup(g => g.ClosingGame())
                .Callback(() => _closingGameMethodCalled = true);
                
            


            Creator = () => new MainMenuState(mockedGame.Object,mockedConfigProvider.Object,
                                              mockedSourceWrapper.Object, dataProvider);      
        }


        [TestMethod]
        // /startgame while no rules Set
        public void If_Calling_Execute__and_command_is_startgame_and_no_rule_set_errorMessage_should_be_returned()
        {
            commands = new List<string>();
            commands.Add("/startgame");
            commands.Add("/closegame");
            _testOutput = "Last Error: Please choose a rule first";

            var state = Creator();
            state.Execute();

            Assert.IsTrue(outputs.Contains(_testOutput));
        }
        

        [TestMethod]
        // /startgame while rule set
        public void If_Calling_Execute__and_command_is_startgame_and_rule_set_state_should_be_switched()
        {
            commands = new List<string>();
            commands.Add("/classic");
            commands.Add("/startgame");

            var state = Creator();
            state.Execute();

            Assert.IsTrue(_switchStateMethodCalled);
        }

        [TestMethod]
        // if /classic  then testOutput should be in the list
        public void If_Calling_Execute__and_command_is_classic_RuleSetMessage_should_be_returned()
        {
            commands = new List<string>();
            commands.Add("/classic");
            commands.Add("/startgame");
            _testOutput = "Ruleset chosen.\nYou can now start the game.";

            var state = Creator();
            state.Execute();

            Assert.IsTrue(outputs.Contains(_testOutput));
            commands.Clear();
        }

        [TestMethod]
        // /closegame 
        public void If_Calling_Execute__and_command_is_closegame_Game_ClosingGame_Method_should_be_called()
        {
            commands = new List<string>();
            commands.Add("/closegame");
            commands.Add("/classic");
            commands.Add("/startgame");

            var state = Creator();
            state.Execute();
            Assert.IsTrue(_closingGameMethodCalled);
            commands.Clear();
        }

    }
}
