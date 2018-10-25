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
    public class GameRunningState_Test
    {
        //Attributes
        private Func<GameRunningState> Creator;
        DataProvider dataProvider = new DataProvider();
        

        private int x;
        private int y;
        private string z;
        private string _TestText;
        private string _input;
        private string _testOutput;
        private IRules _ruleUnderTest;

        private string ReturnInput()
        {
            return _input;
        }

        [TestInitialize]
        public void Setup()
        {
            //Defaults


            //Mocked Configurationprovider
            var mockedConfigProvider = new Mock<IConfigurationProvider>();
            //mockedConfigProvider.Setup(c => c.)


            //Mocked SourceWrapper
            var mockedSourceWrapper = new Mock<ISourceWrapper>();
            mockedSourceWrapper.Setup(s => s.WriteOutput(x, y, z, ConsoleColor.White))
               .Callback(() => _TestText = z);
            mockedSourceWrapper.Setup(s => s.ReadInput())
                .Callback(() => ReturnInput());
            //sourcewrapper.Clear soll nichts machen
            //sourcewrapper.ReadKey wird nicht aufgerufen 

            //Parser und DataProvider sind implementierte Klassen





            //Mock Game
            var mockedGame = new Mock<IGame>();
            mockedGame.Setup(g => g.SwitchRules(_ruleUnderTest))
                .Callback(() => _ruleUnderTest = new ClassicRules(mockedGame.Object));



             var logic = new Logic(mockedGame.Object);

            Creator = () => new GameRunningState(mockedGame.Object,mockedSourceWrapper.Object,
                                                  dataProvider,logic);
        }


        [TestMethod]
        // /help
        public void If_Calling_Execute__and_command_is_help_HelpMessage_should_be_returned()
        {
            _input = "/help";
            _testOutput = "Commands are" + "\n" + "/closegame" + "\n" + "/rolldice";

            var state = Creator();
            state.Execute();

            Assert.AreEqual(_testOutput,_TestText);
        }

        [TestMethod]
        //WaitingForInput
        public void If_Calling_Execute__and_command_is_startgame_and_rule_set_state_should_be_switched()
        {
            _input = "/startgame";

            var state = Creator();
            state.Execute();

            //Assert GameStartingstate is current state
        }

        [TestMethod]
        //WaitingForInput
        public void If_Calling_Execute__and_command_is_classic_RuleSetMessage_should_be_returned()
        {
            _input = "/classic";
            _testOutput = "Ruleset chosen.\nYou can now start the game.";

            var state = Creator();
            state.Execute();
        }

        [TestMethod]
        //WaitingForInput
        public void If_Calling_Execute__and_command_is_closegame_Game_ClosingGame_Method_should_be_called()
        {
            _input = "/closegame";

            var state = Creator();
            state.Execute();

            //Assert game should be closed
        }



    }
}
