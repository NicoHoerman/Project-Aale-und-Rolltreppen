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
    public class ClassicEel_Test
    {
        public Func<IEntity> Creator;

        int pawnLocationUnderTest;
        int eelTopLocationUnderTest;

        bool result;


        [TestInitialize]
        public void Setup()
        {
            eelTopLocationUnderTest = 6;
            pawnLocationUnderTest = 6;


            var mockedPawn = new Mock<IPawn>();
            mockedPawn.Setup(m => m.location).
                Returns(() => pawnLocationUnderTest);


            var mockedEel = new Mock<IEntity>();
            mockedEel.Setup(m => m.top_location).
                Returns(() => eelTopLocationUnderTest);

            Creator = () => new ClassicEel(mockedPawn.Object);
        }
        [TestMethod]
        public void If_Calling_OnSamePositionAs__Return_True_If_Entity_On_Same_Position()
        {

            var eel = Creator();

            result = eel.OnSamePositionAs();

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void If_Calling_OnSamePositionAs__Return_False_If_Entity_Not_On_Same_Position()
        {
            pawnLocationUnderTest = 4;

            var eel = Creator();

            result = eel.OnSamePositionAs();

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void If_Calling_MovePawn__New_Pawn_Location_Should_Be_Lower_Than_Old_Location()
        {


            var eel = Creator();

            eel.SetPawn();

            result = pawnLocationUnderTest < 6 ? true : false;

            Assert.IsTrue(result);

        }
    }
}