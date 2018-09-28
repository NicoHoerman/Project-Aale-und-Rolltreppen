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
        public class ClassicEscalator_Test
        {
            public Func<IEntity> Creator;

            bool result;
            int pawnLocationUnderTest;
            int escalatorBottomLocationUnderTest;

            [TestInitialize]
            public void Setup()
            {
                pawnLocationUnderTest = 6;
                escalatorBottomLocationUnderTest = 6;

                var mockedPawn = new Mock<IPawn>();
                mockedPawn.Setup(m => m.location).
                    Returns(() => pawnLocationUnderTest);

                var mockedEscalator = new Mock<IEntity>();
                mockedEscalator.Setup(m => m.bottom_location).
                    Returns(() => escalatorBottomLocationUnderTest);

                Creator = () => new ClassicEscalator(mockedPawn.Object);
            }

            [TestMethod]
            public void If_Calling_OnSamePositionAs__Return_True_If_Entity_On_Same_Position()
            {

                var escalator = Creator();

                var result = escalator.OnSamePositionAs(pawnLocationUnderTest);

                Assert.IsTrue(result);
            }
            [TestMethod]
            public void If_Calling_OnSamePositionAs__Return_False_If_Entity_Not_On_Same_Position()
            {
                pawnLocationUnderTest = 4;

                var escalator = Creator();

                var result = escalator.OnSamePositionAs(pawnLocationUnderTest);

                Assert.IsFalse(result);
            }

            [TestMethod]
            public void If_Calling_MovePawn__New_Pawn_Location_Should_Be_Higher_Than_Old_Location()
            {

                var escalator = Creator();

                escalator.SetPawn(pawnLocationUnderTest);

                result = pawnLocationUnderTest > 6 ? true : false;

                Assert.IsTrue(result);

            }

        }
}

