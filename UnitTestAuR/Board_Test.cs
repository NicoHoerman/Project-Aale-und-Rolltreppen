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
    /// <summary>
    /// Test for Game Class CreateBord 
    /// </summary>
    [TestClass]
    public class Board_Test
    {
        //Attributes
        private Func<ClassicBoard> Creator;

        private List<IPawn> pawnsUnderTest;
        private int pawnLocationUnderTest;
        private int pawnLocationUnderTest2;

        private List<IEntity> entitiesUnderTest;

        private int eel1TopLocationUnderTest;
        private int eel1BottomLocationUnderTest;

        private int escalator1TopLocationUnderTest;
        private int escalator1BottomLocationUnderTest;

        private int eel2TopLocationUnderTest;
        private int eel2BottomLocationUnderTest;

        private int escalator2TopLocationUnderTest;
        private int escalator2BottomLocationUnderTest;


        
      
        [TestInitialize]
        public void Setup()
        {
            //Defaults


            pawnLocationUnderTest = 1;
            pawnLocationUnderTest2 = 1;

            eel1TopLocationUnderTest = 16;
            eel1BottomLocationUnderTest = 11;

            escalator1TopLocationUnderTest = 18;
            escalator1BottomLocationUnderTest = 14;

            eel2TopLocationUnderTest = 28;
            eel2BottomLocationUnderTest = 24;

            escalator2TopLocationUnderTest = 27;
            escalator2BottomLocationUnderTest = 22;


            //Mock Pawn
            var mockedPawn = new Mock<IPawn>();
            mockedPawn.Setup(p => p.location)
                .Returns(() => pawnLocationUnderTest);
            var mockedPawn2 = new Mock<IPawn>();
            mockedPawn2.Setup(p => p.location)
                .Returns(() => pawnLocationUnderTest2);

            pawnsUnderTest = new List<IPawn>();
            pawnsUnderTest.Add(mockedPawn.Object);
            pawnsUnderTest.Add(mockedPawn2.Object);

            //Mock Eel
            var eelEntity = new Mock<IEntity>();
            eelEntity.Setup(e => e.top_location)
                .Returns(() => eel1TopLocationUnderTest);
            eelEntity.Setup(e => e.bottom_location)
                .Returns(() => eel1BottomLocationUnderTest);

            //Mock Escalator
            var escalatorEntity = new Mock<IEntity>();
            escalatorEntity.Setup(e => e.top_location)
                .Returns(() => escalator1TopLocationUnderTest);
            escalatorEntity.Setup(e => e.bottom_location)
                .Returns(() => escalator1BottomLocationUnderTest);

            //Mock Eel2
            var eel2Entity = new Mock<IEntity>();
            eelEntity.Setup(e => e.top_location)
                .Returns(() => eel2TopLocationUnderTest);
            eelEntity.Setup(e => e.bottom_location)
                .Returns(() => eel2BottomLocationUnderTest);

            //Mock Escalator2
            var escalator2Entity = new Mock<IEntity>();
            escalatorEntity.Setup(e => e.top_location)
                .Returns(() => escalator2TopLocationUnderTest);
            escalatorEntity.Setup(e => e.bottom_location)
                .Returns(() => escalator2BottomLocationUnderTest);

            //List
            entitiesUnderTest = new List<IEntity>();
            entitiesUnderTest.Add(eelEntity.Object);
            entitiesUnderTest.Add(escalatorEntity.Object);
            entitiesUnderTest.Add(eel2Entity.Object);
            entitiesUnderTest.Add(escalator2Entity.Object);

            Creator = () =>
            {
                var result = new ClassicBoard();
                result.Entities = entitiesUnderTest;
                result.Pawns = pawnsUnderTest;
                return result;
            };
        }

       

        [TestMethod]
        // CreateBoard creates a board with all entities 
        public void If_Calling_CreateOutput__Correct_String_Should_Be_Returned()
        {
            var board = Creator();
            var acutalBoard = board.CreateOutput();

            var boardDesignUnderTest =   "  1 [ |1,2| ]" + "  2 [ | , | ]" + "  3 [ | , | ]" + "  4 [ | , | ]\n" +
                                         "  8 [ | , | ]" + "  7 [ | , | ]" + "  6 [ | , | ]" + "  5 [ | , | ]\n" +
                                         "  9 [ | , | ]" + " 10 [ | , | ]" + " 11 [ | , |s]" + " 12 [ | , | ]\n" +
                                         " 16 [S| , | ]" + " 15 [ | , | ]" + " 14 [ | , |e]" + " 13 [ | , | ]\n" +
                                         " 17 [ | , | ]" + " 18 [E| , | ]" + " 19 [ | , | ]" + " 20 [ | , | ]\n" +
                                         " 24 [ | , |s]" + " 23 [ | , | ]" + " 22 [ | , |e]" + " 21 [ | , | ]\n" +
                                         " 25 [ | , | ]" + " 26 [ | , | ]" + " 27 [E| , | ]" + " 28 [S| , | ]\n" +
                                         "                                     30 [ | , | ]" + " 29 [ | , | ]";
            Assert.AreEqual(boardDesignUnderTest, acutalBoard);
        }

    }
}