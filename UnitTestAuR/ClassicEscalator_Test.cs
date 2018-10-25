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

        IPawn _testPawn = new ClassicPawn();

        public bool result;

        [TestInitialize]
        public void Setup()
        {
            _testPawn.location = 6;
           
            Creator = () => new ClassicEscalator();
        }

        [TestMethod]
        public void If_Calling_OnSamePositionAs__Return_True_If_Pawn_On_Same_Position_As_Escalator_Bottom_Location()
        {
            var escalator = Creator();

            escalator.bottom_location = 6;
            
            var result = escalator.OnSamePositionAs(_testPawn);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void If_Calling_OnSamePositionAs__Return_False_If_Pawn_Not_On_Same_Position_As_Escalator_Bottom_Location()
        {
            
            var escalator = Creator();

            escalator.bottom_location = 7;
            
            var result = escalator.OnSamePositionAs(_testPawn);

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void If_Calling_SetPawn__New_Pawn_Location_Should_Be_The_Same_As_The_Escalator_Top_Location()
        {

            var escalator = Creator();
                      
            escalator.top_location = 12;
          
            escalator.SetPawn(_testPawn);

            Assert.AreEqual(escalator.top_location, _testPawn.location);

        }

    }
}

