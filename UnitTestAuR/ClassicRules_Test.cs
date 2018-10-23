//using System;
//using System.Text;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using EelsAndEscalators;
//using EelsAndEscalators.Contracts;
//using EelsAndEscalators.States;
//using EelsAndEscalators.ClassicEandE;
//using System.Xml.Linq;
//using System.Linq;

//namespace UnitTestAuR
//{
//    [TestClass]
//    public class ClassicRules_Test
//    {
//        public Func<IRules> Creator;

//        private List<IPawn> pawnListUnderTest;
//        private List<IEntity> entityListUnderTest;
//        private int NumberOfListContent;
//        private int boardSizeUnderTest;
//        private int diceSidesUnderTest;
//        private int diceResultUnderTest;


//        static string _xmlString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?> <Configurations> <!--Eel--> <config> <toplocation>15</toplocation> <bottomlocation>4</bottomlocation> </config> <!--Escalator--> <config> <toplocation>17</toplocation> <bottomlocation>6</bottomlocation> </config> <!--Pawn--> <config> <location>3</location> <color>2</color> <playerid>1</playerid> </config> </Configurations>";


//        private List<XElement> configList = XDocument.Parse(_xmlString).Elements().ToList();

//        private bool correctDice;




//        [TestInitialize]
//        public void Setup()
//        {
//            //Attribute Arrange
//            var configList = XDocument.Parse(_xmlString).Root.Elements().ToList();

//            boardSizeUnderTest = 10;

//            //mockedBoard Setup
//            var mockedBoard = new Mock<IBoard>();
//            mockedBoard.Setup(m => m.size).
//                Returns(() => boardSizeUnderTest);
//            mockedBoard.Setup(m => m.Entities).
//                Returns(() => entityListUnderTest);
//            mockedBoard.Setup(m => m.Pawns).
//                Returns(() => pawnListUnderTest);

//            //mockedGame Setup
//            var mockedGame = new Mock<IGame>();
//            mockedGame.Setup(m => m.Board).
//                Returns(() => mockedBoard.Object);

//            //mockedConfigurationProvider Setup
//            var mockedConfigurationProvider = new Mock<IConfigurationProvider>();
//            mockedConfigurationProvider.Setup(m => m.GetEntityConfigurations()).
//                Returns(() => configList);

//            Creator = () => new ClassicRules(mockedGame.Object, mockedConfigurationProvider.Object);
//        }

//        [TestMethod]
//        public void If_Calling_SetupEntities__IPawn_Should_Be_Added_To_PawnList_If_A_PawnConfig_Was_Found_In_The_Config_List()
//        {
//            var rules = Creator();
//            rules.SetupEntitites();

//            Assert.IsNotNull(pawnListUnderTest);
//        }

//        [TestMethod]
//        public void If_Calling_SetupEntities__IEntity_Should_Be_Added_To_EntityList_If_A_Eel_Or_EscalatorConfig_Was_Found_In_The_Config_List()
//        {
//            var rules = Creator();
//            rules.SetupEntitites();

//            Assert.IsNotNull(entityListUnderTest);
//        }

//        [TestMethod]
//        public void If_Calling_SetupEntities__The_Created_Pawn_Should_Have_Location_As_Defined_By_Configuration()
//        {

//            var rules = Creator();
//            rules.SetupEntitites();

//            Assert.AreEqual(2, pawnListUnderTest[1].location);
//        }

//        [TestMethod]
//        public void If_Calling_SetupEntities__The_Created_Pawn_Should_Have_Color_As_Defined_By_Configuration()
//        {

//            var rules = Creator();
//            rules.SetupEntitites();

//            Assert.AreEqual(1, pawnListUnderTest[1].color);
//        }

//        [TestMethod]
//        public void If_Calling_SetupEntities__The_Created_Pawn_Should_Have_PlayerID_As_Defined_By_Configuration()
//        {

//            var rules = Creator();
//            rules.SetupEntitites();

//            Assert.AreEqual(1, pawnListUnderTest[1].playerID);
//        }

//        [TestMethod]
//        public void If_Calling_CreateEel__Eel_Should_Have_Bottom_Location_As_Defined_By_Configuration()
//        {
//            var rules = Creator();
//            var result = rules.CreateEel(config);

//            Assert.AreEqual(4, result.bottom_location);
//        }

//        [TestMethod]
//        public void If_Calling_CreateEel__Eel_Should_Have_Top_Location_As_Defined_By_Configuration()
//        {
//            var rules = Creator();
//            var result = rules.CreateEel(config);

//            Assert.AreEqual(15, result.top_location);
//        }

//        [TestMethod]
//        public void If_Calling_CreateEscalator__Escalator_Should_Have_Bottom_Location_As_Defined_By_Configuration()
//        {
//            var rules = Creator();
//            var result = rules.CreateEscalator(config);

//            Assert.AreEqual(6, result.bottom_location);
//        }

//        [TestMethod]
//        public void If_Calling_CreateEscalator__Escalator_Should_Have_Top_Location_As_Defined_By_Configuration()
//        {
//            var rules = Creator();
//            var result = rules.CreateEscalator(config);

//            Assert.AreEqual(17, result.top_location);
//        }

//        [TestMethod]
//        public void If_Calling_CreateBoard__Board_Should_Be_Created_With_The_Correct_Board_Size()
//        {
//            var rules = Creator();
//            var result = rules.CreateBoard();

//            Assert.AreEqual(boardSizeUnderTest, result.size);
//        }

//        [TestMethod]
//        public void If_Calling_CreateBoard__Entity_List_Should_Be_Empty()
//        {
//            var rules = Creator();
//            var result = rules.CreateBoard();

//            NumberOfListContent = result.Entities.Count;

//            Assert.IsNull(NumberOfListContent);
//        }

//        [TestMethod]
//        public void If_Calling_CreateBoard__Pawn_List_Should_Be_Empty()
//        {
//            var rules = Creator();
//            var result = rules.CreateBoard();

//            NumberOfListContent = result.Pawns.Count;

//            Assert.IsNull(NumberOfListContent);
//        }

//        [TestMethod]
//        // RollDice should return a nubmer with in the interval
//        public void If_Calling_RollDice_With_Six_DiceSides_CorrectDiceAttribute_Should_Be_True()
//        {
//            diceSidesUnderTest = 6;
//            var rules = Creator();
//            rules.RollDice();
//            if (diceResultUnderTest == 1 | diceResultUnderTest == 2 | diceResultUnderTest == 3 |
//                diceResultUnderTest == 4 | diceResultUnderTest == 5 | diceResultUnderTest == 6)
//                correctDice = true;

//            Assert.IsTrue(correctDice);
//        }

//    }
//}