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

        private int x;
        private int y;
        private string z;
        private string _TestText;
        private string _input;
        private string errorMsg;

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
            //mockedGame.Setup(g => g.)

            Creator = () => new MainMenuState(mockedGame.Object,mockedConfigProvider.Object,
                                              mockedSourceWrapper.Object, dataProvider);      
        }


        [TestMethod]
        // /startgame while no rules Set
        public void If_Calling_Execute__and_command_is_startgame_and_no_rule_set_errorMessage_should_be_returned()
        {
            _input = "/startgame";
            errorMsg = "Invalid input";

            var state = Creator();
            state.Execute();

            Assert.AreEqual("Last Error:" + errorMsg, "Last Error:" + _TestText);
        }
        
        [TestMethod]
        //WaitingForInput
        public void If_Calling_Execute__and_command_is_startgame_and_rule_set_state_should_be_switched()
        {
            _input = "/startgame";

            var state = Creator();
            state.Execute();
        }

        [TestMethod]
        //WaitingForInput
        public void If_Calling_Execute__and_command_is_classic_RuleSetMessage_should_be_returned()
        {
            _input = "/classic";

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
        }

       

    }
}
