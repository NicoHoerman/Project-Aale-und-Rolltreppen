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
    public class ClassicEscalator_Test
    {
        public Func<IEntity> Creator;

        ClassicPawn _testPawn = new ClassicPawn();
       
        [TestInitialize]
        public void Setup()
        {
            _testPawn.location = 6;


            Creator = () => new ClassicEscalator();
        }

        [TestMethod]
        public void If_Calling_OnSamePositionAs__Return_True_If_Entity_On_Same_Position()
        {

            var escalator = Creator();
            escalator.bottom_location = 6;
            escalator.top_location = 12;
            var result = escalator.OnSamePositionAs(_testPawn);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void If_Calling_OnSamePositionAs__Return_False_If_Entity_Not_On_Same_Position()
        {
            _testPawn.location = 4;

            var escalator = Creator();

            var result = escalator.OnSamePositionAs(_testPawn);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void If_Calling_MovePawn__New_Pawn_Location_Should_Be_Higher_Than_Old_Location()
        {

            var escalator = Creator();

            escalator.SetPawn();

            result = pawnLocationUnderTest > 6 ? true : false;

            Assert.IsTrue(result);

        }

    }
}

