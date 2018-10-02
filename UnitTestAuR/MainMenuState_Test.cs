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


        [TestInitialize]
        public void Setup()
        {
            //Defaults


            //Mock Game
            var mockedGame = new Mock<IGame>();
            //mockedGame.Setup(g => g.)


      //      Creator = () => new MainMenuState(mockedGame.Object);
        }


        [TestMethod]
        //WaitingForInput
        public void If_Calling_WaitingForInput()
        {
          
        }

        [TestMethod]
        //Execute does something while inMenu 
        public void If_Calling_Execute()
        {

        }
    }
}
