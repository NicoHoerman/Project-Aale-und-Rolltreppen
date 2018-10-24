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
    /// Test for  all Logic Class Methods  
    /// </summary>
    [TestClass]
    public class Logic_Test
    {
        //Attributes
        private Func<Logic> Creator;

        private int boardSizeUnderTest;

        private List<IPawn> pawnsUnderTest = new List<IPawn>();

        private List<IEntity> entitiesUnderTest = new List<IEntity>();

        private int pawnLocationUnderTest;

        private int pawn2LocationUnderTest;

        private bool gameFinishedUnderTest;

        private bool playerExceedsBoardUnderTest;
        
        private int pawnPlayerIdUnderTest;

        private int pawn2PlayerIdUnderTest;

        private int pawnIdUnderTest;

        private int pawnColorUnderTest;
        
        private int diceResultUnderTest;

        private int eelTopLocationUnderTest;

        private int eelBottomLocationUnderTest;

        private int escalatorTopLocationUnderTest;

        private int escalatorBottomLocationUnderTest;

        private EntityType escalatorEntityTypeUnderTest;

        private EntityType eelEntityTypeUnderTest;

        private TurnState currentStateUnderTest;

        public void SetPawnUnderTestEel(IPawn pawn)
        {
            pawnLocationUnderTest = eelBottomLocationUnderTest;
        }

        public void SetPawnUnderTestEscalator(IPawn pawn)
        {
            pawnLocationUnderTest = escalatorTopLocationUnderTest;
        }

        public bool OnSamePositionAsUnderTest(IPawn pawn)
        {
            return eelTopLocationUnderTest == pawnLocationUnderTest ? true : false;
        }

        public void movePawnUnderTest(int diceResultUnderTest)
        {
            pawnLocationUnderTest += diceResultUnderTest;
        }

        
        [TestInitialize]
        public void Setup()
        {
            // Defaults
            
            boardSizeUnderTest = 10;

            pawnLocationUnderTest = 10;
            pawnPlayerIdUnderTest = 1;
            pawnIdUnderTest = 3;
            pawnColorUnderTest = 2;

            pawn2LocationUnderTest = 4;
            pawn2PlayerIdUnderTest = 2;
            
            diceResultUnderTest = 6;

         
            // Mock Board
            var mockedBoard = new Mock<IBoard>();
            mockedBoard.Setup(m => m.size)
                .Returns(() => boardSizeUnderTest);
            mockedBoard.Setup(m => m.Pawns)
                .Returns(() => pawnsUnderTest);
            mockedBoard.Setup(m => m.Entities)
                .Returns(() => entitiesUnderTest);


            // Mock Pawn
            var mockedPawn = new Mock<IPawn>();
            mockedPawn.Setup(p => p.location)
                .Returns(() => pawnLocationUnderTest);
            mockedPawn.Setup(p => p.playerID)
                .Returns(() => pawnPlayerIdUnderTest);
            mockedPawn.Setup(p => p.Id)
                .Returns(() => pawnIdUnderTest);
            mockedPawn.Setup(p => p.color)
                .Returns(() => pawnColorUnderTest);
            mockedPawn.Setup(p => p.MovePawn(diceResultUnderTest))
                .Callback(() => movePawnUnderTest(diceResultUnderTest));
            
            pawnsUnderTest.Add(mockedPawn.Object);

            // Mock Pawn2

            var mockedPawn2 = new Mock<IPawn>();
            mockedPawn2.Setup(p => p.location)
                .Returns(() => pawn2LocationUnderTest);
            mockedPawn2.Setup(p => p.playerID)
                .Returns(() => pawn2PlayerIdUnderTest);          
            /*mockedPawn2.Setup(p => p.Id)
                .Returns(() => pawnIdUnderTest);
            mockedPawn2.Setup(p => p.color)
                .Returns(() => pawnColorUnderTest);
            mockedPawn2.Setup(p => p.MovePawn(diceResultUnderTest))
                .Callback(() => movePawnUnderTest()); */

            pawnsUnderTest.Add(mockedPawn2.Object);

            // Mock Eel
            var mockedEel = new Mock<IEntity>();
            mockedEel.Setup(e => e.type)
                .Returns(() => eelEntityTypeUnderTest);
            mockedEel.Setup(e => e.bottom_location)
                .Returns(() => eelBottomLocationUnderTest);
            mockedEel.Setup(e => e.top_location)
                .Returns(() => eelTopLocationUnderTest);
            mockedEel.Setup(e => e.OnSamePositionAs(mockedPawn.Object))
                .Callback(() => OnSamePositionAsUnderTest(mockedPawn.Object));
            mockedEel.Setup(e => e.SetPawn(mockedPawn.Object))
                .Callback(() => SetPawnUnderTestEel(mockedPawn.Object));
                

            entitiesUnderTest.Add(mockedEel.Object);

            // Mock Escalator
            var mockedEscalator = new Mock<IEntity>();
            mockedEscalator.Setup(e => e.type)
                .Returns(() => escalatorEntityTypeUnderTest);
            mockedEscalator.Setup(e => e.bottom_location)
                .Returns(() => escalatorBottomLocationUnderTest);
            mockedEscalator.Setup(e => e.top_location)
                .Returns(() => escalatorTopLocationUnderTest);
            mockedEel.Setup(e => e.OnSamePositionAs(mockedPawn.Object))
                .Callback(() => OnSamePositionAsUnderTest(mockedPawn.Object));
            mockedEel.Setup(e => e.SetPawn(mockedPawn.Object))
                .Callback(() => SetPawnUnderTestEscalator(mockedPawn.Object));

            entitiesUnderTest.Add(mockedEscalator.Object);

            // Mock Rules
            var mockedRules = new Mock<IRules>();
            mockedRules.Setup(r => r.DiceResult)
                .Returns(() => diceResultUnderTest);
            

            // Mock Game
            var mockedGame = new Mock<IGame>();
            mockedGame.Setup(m => m.Board).
                Returns(mockedBoard.Object);
            mockedGame.Setup(m => m.Rules).
                Returns(() => mockedRules.Object);                     
            
            Creator = () => new Logic(mockedGame.Object);
          
            
        }



        [TestMethod]
        // CheckIfGameFinished is called after every turn
        // checks if one pawn location is on the last field
        // Test for Pawn is on last field
        //[ExpectedException(typeof(ArgumentOutOfRangeException),
            //"Pawn is not on the Board anymore")]
        public void If_Calling_Check_If_Game_Finished_With_Pawn_On_Endpoint__GameFinished_Should_Be_True()
        {
                                   
            var logic = Creator();
                                
            currentStateUnderTest = logic.CheckIfGameFinished(logic.GetPawn());

            if (currentStateUnderTest == TurnState.GameFinished)
                gameFinishedUnderTest = true;
            else
                gameFinishedUnderTest = false;

            Assert.IsTrue(gameFinishedUnderTest);
        }

        [TestMethod]
        // Test for Pawn is not on last field
        //[ExpectedException(typeof(ArgumentOutOfRangeException),
        // "Pawn is not on the Board anymore")]
        public void If_Calling_Check_If_Game_Finished_With_Pawn_Before_Endpoint__GameFinished_Should_Be_False()
        {
            pawnLocationUnderTest = 3;


            var logic = Creator();
            
            currentStateUnderTest = logic.CheckIfGameFinished(logic.GetPawn());

            if (currentStateUnderTest == TurnState.GameFinished)
                gameFinishedUnderTest = true;
            else
                gameFinishedUnderTest = false;
                
            Assert.IsFalse(gameFinishedUnderTest);
        }

        

        [TestMethod]
        //Make Turn should be canceld if dice result exceeds the boardsize
        //[ExpectedException(typeof(ArgumentOutOfRangeException),
         //"Pawn is not on the Board anymore")]
        public void If_Calling_MakeTurn_And_Player_Exceeds_Board__TurnState_Should_Be_Changed_To_PlayerExceedsBoard()
        {
            pawnLocationUnderTest = 7;

            var logic = Creator();
            currentStateUnderTest = logic.MakeTurn();

            if (currentStateUnderTest == TurnState.PlayerExceedsBoard)
                playerExceedsBoardUnderTest = true;
            else
                playerExceedsBoardUnderTest = false;

            Assert.IsTrue(playerExceedsBoardUnderTest);
        }


        [TestMethod]
        //Make Turn when dice result would not exceed the boardsize 
        //[ExpectedException(typeof(ArgumentOutOfRangeException),
         //"Pawn is not on the Board anymore")]
        public void If_Calling_MakeTurn_And_Player_Does_Not_Exceed_Board__Move_Pawn()
        {
            pawnLocationUnderTest = 2;
            var logic = Creator();
            logic.MakeTurn();

            Assert.AreNotEqual(2, pawnLocationUnderTest);
        }

        [TestMethod]

        public void If_Calling_Make_Turn_And_Current_Pawn_Lands_On_Eel__Eeel_Should_Set_Pawn_To_New_Location()
        {
            
            pawnLocationUnderTest = 5;
            diceResultUnderTest = 3;
            eelTopLocationUnderTest = 8;
            eelBottomLocationUnderTest = 3;
            


            var logic = Creator();
            
            logic.MakeTurn();

            Assert.AreEqual(eelBottomLocationUnderTest, pawnLocationUnderTest);
        }

        [TestMethod]

        public void If_Calling_Get_Pawn__The_Pawn_With_The_Matching_Player_ID_Should_Be_Returned()
        {
            
            var logic = Creator();

            var pawnUnderTest = logic.GetPawn();

            Assert.AreEqual(logic.CurrentPlayerID, pawnUnderTest.playerID);
        }

        [TestMethod]

        public void If_Calling_Next_Player__Current_Player_ID_Should_Be_Changed_To_The_Next_Players_ID()
        {
            var logic = Creator();           

            logic.NextPlayer();

            Assert.AreNotEqual(1, logic.CurrentPlayerID);

        }

        


    }
}



