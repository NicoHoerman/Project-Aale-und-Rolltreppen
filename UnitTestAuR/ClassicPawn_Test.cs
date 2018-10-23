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
        public Func<ClassicPawn> Creator;

        int fieldsToMove;

        [TestInitialize]
        public void Setup()
        {
            fieldsToMove = 5;

            Creator = () => new ClassicPawn();
        }

        [TestMethod]
        public void If_Calling_MovePawn__Move_Pawn_By_Dice_Result()
        {
            var pawn = Creator();
            pawn.location = 4;
            pawn.MovePawn(fieldsToMove);

            Assert.AreEqual(9, pawn.location);
        }
    }
}
