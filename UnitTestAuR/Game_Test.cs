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
    public class Game_Test
    {
        public Func<Game> Creator;

        //Attributes

        [TestInitialize]
        public void Setup()
        {
            //Defaults

            //Mocks

            Creator = () => new Game();
        }

        [TestMethod]
        public void If_Calling_MovePawn__Move_Pawn_By_Dice_Result()
        {
            //Arrange
            var game = Creator();
            
            //Act

            //Assert
        }
    }
}
