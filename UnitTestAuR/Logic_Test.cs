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
    /// <summary>
    /// Test for  all Logic Class Methods  
    /// </summary>
    [TestClass]
    public class Logic_Test
    {
        //Attributes
        private Func<Logic> Creator;
        private bool gameFinishedUnderTest;
        private int boardSizeUnderTest;
        private List<IPawn> pawnsUnderTest = new List<IPawn>();
        private int pawnLocationUnderTest;

        private int pawnPlayerUnderTest;
        private int playerUnderTest;

        private int diceResultUnderTest;

        [TestInitialize]
        public void Setup()
        {
            //Defaults
            gameFinishedUnderTest = false;
            boardSizeUnderTest = 10;
            pawnLocationUnderTest = 5;
            pawnPlayerUnderTest = 1;
            playerUnderTest = 1;
            diceResultUnderTest = 6;

            //Mock Board
            var mockedBoard = new Mock<IBoard>();
            mockedBoard.Setup(m => m.size)
                .Returns(() => boardSizeUnderTest);
            mockedBoard.Setup(m => m.Pawns)
                .Returns(() => pawnsUnderTest);

            // Mock Pawn
            var mockedPawn = new Mock<IPawn>();
            mockedPawn.Setup(p => p.location)
                .Returns(() => pawnLocationUnderTest);
            mockedPawn.Setup(p => p.playerID)
                .Returns(() => pawnPlayerUnderTest);
            pawnsUnderTest.Add(mockedPawn.Object);

            //Mock Rules
            var mockedRules = new Mock<IRules>();
            mockedRules.Setup(r => r.diceResult)
                .Returns(() => diceResultUnderTest);

            // Mock Game
            var mockedGame = new Mock<IGame>();
            mockedGame.Setup(m => m.Board).
                Returns(mockedBoard.Object);
            mockedGame.Setup(m => m.Board.Pawns).
                Returns(pawnsUnderTest);
            mockedGame.Setup(m => m.Rules).
                Returns(() => mockedRules.Object);


            Creator = () => new Logic(mockedGame.Object);
        }



        [TestMethod]
        // CheckIfGameFinished is called after every turn
        // checks if one pawn location is on the last field
        // Test for Pawn is on last field
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Pawn is not on the Board anymore")]
        public void If_Calling_CheckIfGameFinished_With_Pawn_On_Endpoint_GameFinished_Should_Be_True()
        {
            boardSizeUnderTest = 10;
            pawnLocationUnderTest = 10;
            gameFinishedUnderTest = false;
            var logic = Creator();
            logic.CheckIfGameFinished();

            Assert.IsTrue(gameFinishedUnderTest);
        }

        [TestMethod]
        // Test for Pawn is not on last field
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Pawn is not on the Board anymore")]
        public void If_Calling_CheckIfGameFinished_With_Pawn_Before_Endpoint_GameFinished_Should_Be_False()
        {
            boardSizeUnderTest = 10;
            pawnLocationUnderTest = 5;
            var logic = Creator();
            logic.CheckIfGameFinished();

            Assert.IsFalse(gameFinishedUnderTest);
        }

        [TestMethod]
        // ChoosePawn chooses the right pawn through bool Attribute in StateMachine
        // Test for PlayerOne's Pawn 
        public void If_Calling_ChoosePawn_Pawn_Should_Be_Chosen_For_Player_One()
        {
            playerUnderTest = 1;
            pawnPlayerUnderTest = 1;
            var logic = Creator();
            var correctpawn =logic.GetPawn();

            Assert.AreEqual(pawnPlayerUnderTest, correctpawn.playerID);
        }

        [TestMethod]
        //Test for PlayerTwo's Pawn 
        public void If_Calling_ChoosePawn_Pawn_Should_Be_Chosen_For_Player_Two()
        {
            playerUnderTest = 2;
            pawnPlayerUnderTest = 2;
            var logic = Creator();
            var correctpawn = logic.GetPawn();

            Assert.AreEqual(pawnPlayerUnderTest, correctpawn.playerID);
        }

        [TestMethod]
        //Make Turn should be canceld if dice result exceeds the boardsize
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Pawn is not on the Board anymore")]
        public void If_Calling_MakeTurn_And_DiceResult_Too_High_Cancel_Method()
        {
            boardSizeUnderTest = 15;
            pawnLocationUnderTest = 13;
            diceResultUnderTest = 5;
            var logic = Creator();
            logic.MakeTurn(diceResultUnderTest);

            Assert.AreEqual(pawnLocationUnderTest, pawnLocationUnderTest);
        }


        [TestMethod]
        //Make Turn when dice result would not exceed the boardsize 
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Pawn is not on the Board anymore")]
        public void If_Calling_MakeTurn_And_DiceResult_Fits_Continue_Method()
        {
            boardSizeUnderTest = 15;
            pawnLocationUnderTest = 13;
            diceResultUnderTest = 2;
            var logic = Creator();
            logic.MakeTurn(diceResultUnderTest);

            Assert.AreNotEqual(pawnLocationUnderTest, pawnLocationUnderTest);
        }


    }
}



