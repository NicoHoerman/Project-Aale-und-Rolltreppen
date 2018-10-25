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
        private int pawnPlayerIDUnderTest;

        private int pawnLocationUnderTest2;
        private int pawnPlayerIDUnderTest2;

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
            pawnPlayerIDUnderTest = 1;
            pawnLocationUnderTest2 = 1;
            pawnPlayerIDUnderTest2 = 2;

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
            mockedPawn.Setup(p => p.type)
                .Returns(() => EntityType.Pawn);
            mockedPawn.Setup(p => p.playerID)
                .Returns(() => pawnPlayerIDUnderTest);

            var mockedPawn2 = new Mock<IPawn>();
            mockedPawn2.Setup(p => p.location)
                .Returns(() => pawnLocationUnderTest2);
            mockedPawn2.Setup(p => p.type)
                .Returns(() => EntityType.Pawn);
            mockedPawn2.Setup(p => p.playerID)
                .Returns(() => pawnPlayerIDUnderTest2);

            pawnsUnderTest = new List<IPawn>();
            pawnsUnderTest.Add(mockedPawn.Object);
            pawnsUnderTest.Add(mockedPawn2.Object);

            //Mock Eel
            var eelEntity = new Mock<IEntity>();
            eelEntity.Setup(e => e.top_location)
                .Returns(() => eel1TopLocationUnderTest);
            eelEntity.Setup(e => e.bottom_location)
                .Returns(() => eel1BottomLocationUnderTest);
            eelEntity.Setup(e => e.type)
                .Returns(() => EntityType.Eel);

            //Mock Escalator
            var escalatorEntity = new Mock<IEntity>();
            escalatorEntity.Setup(e => e.top_location)
                .Returns(() => escalator1TopLocationUnderTest);
            escalatorEntity.Setup(e => e.bottom_location)
                .Returns(() => escalator1BottomLocationUnderTest);
            escalatorEntity.Setup(e => e.type)
                .Returns(() => EntityType.Escalator);

            //Mock Eel2
            var eel2Entity = new Mock<IEntity>();
            eel2Entity.Setup(e => e.top_location)
                .Returns(() => eel2TopLocationUnderTest);
            eel2Entity.Setup(e => e.bottom_location)
                .Returns(() => eel2BottomLocationUnderTest);
            eel2Entity.Setup(e => e.type)
                .Returns(() => EntityType.Eel);

            //Mock Escalator2
            var escalator2Entity = new Mock<IEntity>();
            escalator2Entity.Setup(e => e.top_location)
                .Returns(() => escalator2TopLocationUnderTest);
            escalator2Entity.Setup(e => e.bottom_location)
                .Returns(() => escalator2BottomLocationUnderTest);
            escalator2Entity.Setup(e => e.type)
                .Returns(() => EntityType.Escalator);

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

            var boardDesignUnderTest =  " 30 [ | , | ]  29 [ | , | ]  28 [S| , | ]  27 [E| , | ] \n"+
                                        " 23 [ | , | ]  24 [ | , |s]  25 [ | , | ]  26 [ | , | ] \n" +
                                        " 22 [ | , |e]  21 [ | , | ]  20 [ | , | ]  19 [ | , | ] \n" +
                                        " 15 [ | , | ]  16 [S| , | ]  17 [ | , | ]  18 [E| , | ] \n" +
                                        " 14 [ | , |e]  13 [ | , | ]  12 [ | , | ]  11 [ | , |s] \n" +
                                        "  7 [ | , | ]   8 [ | , | ]   9 [ | , | ]  10 [ | , | ] \n" +
                                        "  6 [ | , | ]   5 [ | , | ]   4 [ | , | ]   3 [ | , | ] \n" +
                                        "                              1 [ |1,2| ]   2 [ | , | ] \n";
   
            Assert.AreEqual(boardDesignUnderTest, acutalBoard);
        }

    }
}