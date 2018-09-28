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
    [TestClass]
    public class ClassicRules_Test
    {
        public Func<IRules> Creator;

        private List<IPawn> pawnListUnderTest;
        private List<IEntity> entityListUnderTest;

        private int NumberOfListContent;
        private int boardSizeUnderTest;
        private int diceSidesUnderTest;

        private bool correctDice;

        PawnConfig pawnConfig = new PawnConfig();
        EelConfig eelConfig = new EelConfig();
        EscalatorConfig escalatorConfig = new EscalatorConfig();

        [TestInitialize]
        public void Setup()
        {
            //Attribute Arrange
            escalatorConfig.bottom_location = 6;
            eelConfig.top_location = 5;
            pawnConfig.location = 4;
            pawnConfig.playerID = 1;
            pawnConfig.color = 2;

            boardSizeUnderTest = 10;



            //mockedBoard Setup
            var mockedBoard = new Mock<IBoard>();
            mockedBoard.Setup(m => m.size).
                Returns(() => boardSizeUnderTest);
            mockedBoard.Setup(m => m.Entities).
                Returns(() => entityListUnderTest);
            mockedBoard.Setup(m => m.Pawns).
                Returns(() => pawnListUnderTest);

            //mockedGame Setup
            var mockedGame = new Mock<IGame>();
            mockedGame.Setup(m => m.Board).
                Returns(() => mockedBoard.Object);

            Creator = () => new ClassicRules(mockedGame.Object);
        }

        [TestMethod]
        public void If_Calling_CreatePawn__Pawn_Should_Have_Location_As_Defined_By_Configuration()
        {

            var rules = Creator();
            var result = rules.CreatePawn(pawnConfig);

            Assert.AreEqual(pawnConfig.location, result.location);
        }

        [TestMethod]
        public void If_Calling_CreatePawn__Pawn_Should_Have_Color_As_Defined_By_Configuration()
        {

            var rules = Creator();
            var result = rules.CreatePawn(pawnConfig);

            Assert.AreEqual(pawnConfig.color, result.color);
        }

        [TestMethod]
        public void If_Calling_CreatePawn__Pawn_Should_Have_PlayerID_As_Defined_By_Configuration()
        {

            var rules = Creator();
            var result = rules.CreatePawn(pawnConfig);

            Assert.AreEqual(pawnConfig.playerID, result.playerID);
        }

        [TestMethod]
        public void If_Calling_CreateEel__Eel_Should_Have_Bottom_Location_As_Defined_By_Configuration()
        {
            var rules = Creator();
            var result = rules.CreateEel(eelConfig);

            Assert.AreEqual(eelConfig.bottom_location, result.bottom_location);
        }

        [TestMethod]
        public void If_Calling_CreateEel__Eel_Should_Have_Top_Location_As_Defined_By_Configuration()
        {
            var rules = Creator();
            var result = rules.CreateEel(eelConfig);

            Assert.AreEqual(eelConfig.top_location, result.top_location);
        }

        [TestMethod]
        public void If_Calling_CreateEscalator__Escalator_Should_Have_Bottom_Location_As_Defined_By_Configuration()
        {
            var rules = Creator();
            var result = rules.CreateEscalator(escalatorConfig);

            Assert.AreEqual(escalatorConfig.bottom_location, result.bottom_location);
        }

        [TestMethod]
        public void If_Calling_CreateEscalator__Escalator_Should_Have_Top_Location_As_Defined_By_Configuration()
        {
            var rules = Creator();
            var result = rules.CreateEscalator(escalatorConfig);

            Assert.AreEqual(escalatorConfig.top_location, result.top_location);
        }

        [TestMethod]
        public void If_Calling_CreateBoard__Board_Should_Be_Created_With_The_Correct_Board_Size()
        {
            var rules = Creator();
            var result = rules.CreateBoard();

            Assert.AreEqual(boardSizeUnderTest, result.size);
        }

        [TestMethod]
        public void If_Calling_CreateBoard__Entity_List_Should_Be_Empty()
        {
            var rules = Creator();
            var result = rules.CreateBoard();

            NumberOfListContent = result.Entities.Count;

            Assert.IsNull(NumberOfListContent);
        }

        [TestMethod]
        public void If_Calling_CreateBoard__Pawn_List_Should_Be_Empty()
        {
            var rules = Creator();
            var result = rules.CreateBoard();

            NumberOfListContent = result.Pawns.Count;

            Assert.IsNull(NumberOfListContent);
        }

        [TestMethod]
        // RollDice should return a nubmer with in the interval
        public void If_Calling_RollDice_With_Six_DiceSides_CorrectDiceAttribute_Should_Be_True()
        {
            diceSidesUnderTest = 6;
            var rules = Creator();
            var diceResult = rules.RollDice();
            if (diceResult == 1 | diceResult == 2 | diceResult == 3 |
                diceResult == 4 | diceResult == 5 | diceResult == 6)
                correctDice = true;

            Assert.IsTrue(correctDice);
        }

    }
}