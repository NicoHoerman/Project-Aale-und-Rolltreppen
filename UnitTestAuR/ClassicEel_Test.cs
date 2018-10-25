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
            
            _testPawn.location = 6;

            Creator = () => new ClassicEel();
        }

        [TestMethod]
        public void If_Calling_OnSamePositionAs__Return_True_If_Pawn_On_Same_Position_As_Eel_Top_Location()
        {
            var eel = Creator();
            
            eel.top_location = 6;

            result = eel.OnSamePositionAs(_testPawn);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void If_Calling_OnSamePositionAs__Return_False_If_Pawn_Not_On_Same_Position_As_Eel_Top_Location()
        {           
            var eel = Creator();

            eel.top_location = 7;
            
            result = eel.OnSamePositionAs(_testPawn);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void If_Calling_SetPawn__New_Pawn_Location_Should_Be_The_Same_As_The_Eel_Bottom_Location()
        {

            var eel = Creator();

            eel.bottom_location = 3;
            
            eel.SetPawn(_testPawn);
           
            Assert.AreEqual(eel.bottom_location, _testPawn.location);

        }
    }
}