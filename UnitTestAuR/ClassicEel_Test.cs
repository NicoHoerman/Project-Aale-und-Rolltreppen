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
    public class ClassicEel_Test
    {
        public Func<IEntity> Creator;

        ClassicPawn _testPawn = new ClassicPawn();
        private bool result;


        [TestInitialize]
        public void Setup()
        {
            //eelTopLocationUnderTest = 6;
            _testPawn.location = 6;

            Creator = () => new ClassicEel();
        }
        [TestMethod]
        public void If_Calling_OnSamePositionAs__Return_True_If_Entity_On_Same_Position()
        {

            var eel = Creator();
            eel.bottom_location = 3;
            eel.top_location = 6;

            result = eel.OnSamePositionAs(_testPawn);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void If_Calling_OnSamePositionAs__Return_False_If_Entity_Not_On_Same_Position()
        {
            _testPawn.location = 4;

            var eel = Creator();
            eel.top_location = 6;
            eel.bottom_location = 3;
            result = eel.OnSamePositionAs(_testPawn);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void If_Calling_MovePawn__New_Pawn_Location_Should_Be_Lower_Than_Old_Location()
        {


            var eel = Creator();
            eel.top_location = 6;
            eel.bottom_location = 3;
            eel.SetPawn(_testPawn);

            result = _testPawn.location < 6 ? true : false;

            Assert.IsTrue(result);

        }
    }
}