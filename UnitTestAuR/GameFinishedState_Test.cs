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
    public class GameFinishedState_Test
    {

        public Func<GameFinishedState> Creator;

        private int winnerUnderTest;
       

        [TestInitialize]
        public void Setup()
        {
            

            var mockedGame = new Mock<IGame>();

            var mockedSourceWrapper = new Mock<ISourceWrapper>();

            var dataProviderUnderTest = new DataProvider();

            Creator = () => new GameFinishedState(mockedGame.Object, mockedSourceWrapper.Object, 
                                                    dataProviderUnderTest, winnerUnderTest);

            winnerUnderTest = 2;

        }

        [TestMethod]
        public void If_Calling_Execute__Correct_Player_Id_Should_Be_Displayed_In_The_Winning_Message()
        {
            var _testOutput = "Player Two Wins\nEeeeelssss";

            var state = Creator();

            state.Execute();

            Assert.AreEqual(_testOutput, state._finishinfo);

        }
    }
}
