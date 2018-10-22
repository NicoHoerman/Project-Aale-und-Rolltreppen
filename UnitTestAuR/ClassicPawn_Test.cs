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
    public class ClassicPawn_Test
    {
        public Func<IPawn> Creator;

        int _testinput;
        int pawnLocationUnderTest;

        [TestInitialize]
        public void Setup()
        {
            _testinput = 4;
            pawnLocationUnderTest = 4;

            Creator = () => new ClassicPawn
            {
                location = pawnLocationUnderTest
            };
        }

        [TestMethod]
        public void If_Calling_MovePawn__Move_Pawn_By_Dice_Result()
        {
            var pawn = Creator();
            pawn.MovePawn(_testinput);

            Assert.AreEqual(8, pawn.location);
        }
    }
}
