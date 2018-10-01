using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EelsAndEscalators;
using EelsAndEscalators.Contracts;
using EelsAndEscalators.States;

namespace UnitTestAuR
{
    /// <summary>
    /// Test for Game Class CreateBord and RollDice
    /// </summary>
    [TestClass]
    public class Game_Test
    {
        //Attributes
        private Func<Game> Creator;

        private List<IPawn> pawnsUnderTest;
        private int pawnLocationUnderTest;
        private int pawnLocationUnderTest2;
        private List<IEntity> entitiesUnderTest;

        private int boardSizeUnderTest;
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
            boardSizeUnderTest = 10;
            eel1TopLocationUnderTest = 5;
            eel1BottomLocationUnderTest = 3;
            escalator1TopLocationUnderTest = 8;
            escalator1BottomLocationUnderTest = 2;
            pawnLocationUnderTest = 1;
            pawnLocationUnderTest2 = 1;
           

            //Rules Mock
            var mockedRules = new Mock<IRules>();
          
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

            //Mock Escalator
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

            //Board Mock
            var mockedBoard = new Mock<IBoard>();
            mockedBoard.Setup(b => b.size)
                .Returns(() => boardSizeUnderTest);
            mockedBoard.Setup(b => b.Pawns)
                .Returns(() => pawnsUnderTest);
            mockedBoard.Setup(b => b.Entities)
                .Returns(() => entitiesUnderTest);

            Creator = () => new Game(mockedBoard.Object, mockedRules.Object);
        }

       

        [TestMethod]
        // CreateBoard creates a board with all entities 
        public void If_Calling_CreateBoard__Correct_String_Should_Be_Returned()
        {
            boardSizeUnderTest = 30;
            pawnLocationUnderTest = 0;
            pawnLocationUnderTest2 = 0;

            eel1TopLocationUnderTest = 16;
            eel1BottomLocationUnderTest = 11;

            escalator1TopLocationUnderTest = 18;
            escalator1BottomLocationUnderTest = 14;

            eel2TopLocationUnderTest = 28;
            eel2BottomLocationUnderTest = 24;

            escalator2TopLocationUnderTest = 27;
            escalator2BottomLocationUnderTest = 22;


            var game = Creator();

            var acutalBoard = game.CreateBoard();

            var boardDesignUnderTest = "30[    ]" + "29[    ]" + "28[S   ]" + "27[E   ]" + "26[    ]" +
                                       "25[    ]" + "24[   s]" + "23[    ]" + "22[   e]" + "21[    ]" +
                                       "20[    ]" + "19[    ]" + "18[E   ]" + "17[    ]" + "16[S   ]" +
                                       "15[    ]" + "14[   e]" + "13[    ]" + "12[    ]" + "11[   s]" +
                                       "10[    ]" + "09[    ]" + "08[    ]" + "07[    ]" + "06[    ]" +
                                       "05[    ]" + "04[    ]" + "03[    ]" + "02[    ]" + "01[ 12 ]";
            Assert.AreEqual(boardDesignUnderTest, acutalBoard);
        }
    }
}
