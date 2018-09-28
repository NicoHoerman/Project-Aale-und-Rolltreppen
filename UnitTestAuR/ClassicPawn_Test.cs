using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EelsAndEscalators;
using EelsAndEscalators.Contracts;
using EelsAndEscalators.Configurations;
using EelsAndEscalators.States;
using EelsAndEscalators.ClassicEandE;

namespace UnitTestAuR
{
        [TestClass]
        public class ClassicPawn_Test
        {
            public Func<IPawn> Creator;

            int diceResultUnderTest;
            int pawnLocationUnderTest;

            [TestInitialize]
            public void Setup()
            {
                diceResultUnderTest = 5;
                pawnLocationUnderTest = 4;

                var mockedRules = new Mock<IRules>();
                mockedRules.Setup(m => m.diceResult).
                    Returns(() => diceResultUnderTest);

                var mockedGame = new Mock<IGame>();
                mockedGame.Setup(m => m.Rules).
                    Returns(() => mockedRules.Object);

                var mockedPawn = new Mock<IPawn>();
                mockedPawn.Setup(m => m.location).
                    Returns(() => pawnLocationUnderTest);

                Creator = () => new ClassicPawn(mockedGame.Object);

            }

            [TestMethod]
            public void If_Calling_MovePawn__Move_Pawn_By_Dice_Result()
            {

                var pawn = Creator();
                pawn.MovePawn();

                Assert.AreEqual(9, pawn.location);
            }
        }
}
