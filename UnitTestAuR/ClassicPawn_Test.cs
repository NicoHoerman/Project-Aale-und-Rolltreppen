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

            int diceResultUnderTest;
            int pawnLocationUnderTest;

            [TestInitialize]
            public void Setup()
            {
                diceResultUnderTest = 5;
                pawnLocationUnderTest = 4;

                var mockedRules = new Mock<IRules>();
                mockedRules.Setup(m => m.DiceResult).
                    Returns(() => diceResultUnderTest);

                var mockedPawn = new Mock<IPawn>();
                mockedPawn.Setup(m => m.location).
                    Returns(() => pawnLocationUnderTest);

                var mockedGame = new Mock<IGame>();
                mockedGame.Setup(m => m.Rules).
                    Returns(() => mockedRules.Object);
                //mockedGame.Setup(m => m.Board.Pawn).
                //    Returns(() => mockedPawn.Object);

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
