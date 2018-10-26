using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EelsAndEscalators;
using EelsAndEscalators.Contracts;
using EelsAndEscalators.States;
using EelsAndEscalators.ClassicEandE;
using System.Xml.Linq;
using System.Linq;



namespace UnitTestAuR
{

    [TestClass]
    public class ClassicRules_Test : IEquatable<ClassicBoard>
    {
        public Func<IRules> Creator;

        private List<IPawn> pawnListUnderTest = new List<IPawn>();

        private List<IEntity> entityListUnderTest = new List<IEntity>();
       
        private int boardSizeUnderTest;

        private int blub;

        private int boardMaxWidthUnderTest;

        static string _xmlString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?> <Configurations> <!--Eel--> <config> <entitytype>0</entitytype> <toplocation>15</toplocation> <bottomlocation>4</bottomlocation> </config> <!--Escalator--> <config> <entitytype>1</entitytype> <toplocation>17</toplocation> <bottomlocation>6</bottomlocation> </config> <!--Pawn--> <config> <entitytype>2</entitytype> <location>3</location> <color>2</color> <playerid>1</playerid> </config> </Configurations>";

        private List<XElement> configList = XDocument.Parse(_xmlString).Elements().ToList();
       
        private bool correctDice;


        public override bool Equals(Object obj)
        {
            var other = obj as ClassicBoard;
            if (other == null) return false;

            return Equals(other);
        }

        public bool Equals(ClassicBoard other)
        {
            if (other == null)
            {
                return false;
            }

            else return true;
        }

        public override int GetHashCode()
        {
            return blub;
        }


        [TestInitialize]
        public void Setup()
        {
            //Attribute Arrange
            var configList = XDocument.Parse(_xmlString).Root.Elements().ToList();

            boardSizeUnderTest = 30;

            boardMaxWidthUnderTest = 8;

            //mockedBoard Setup
            var mockedBoard = new Mock<IBoard>();
            mockedBoard.Setup(m => m.size)
                .Returns(() => boardSizeUnderTest);
            mockedBoard.Setup(m => m.MaxWidth)
                .Returns(() => boardMaxWidthUnderTest);
            mockedBoard.Setup(m => m.Entities)
                .Returns(() => entityListUnderTest);
            mockedBoard.Setup(m => m.Pawns)
                .Returns(() => pawnListUnderTest);
                                             
            
            //mockedGame Setup
            var mockedGame = new Mock<IGame>();
            mockedGame.Setup(m => m.Board)
                .Returns(() => mockedBoard.Object);

            //mockedConfigurationProvider Setup
            var mockedConfigurationProvider = new Mock<IConfigurationProvider>();
            mockedConfigurationProvider.Setup(m => m.GetEntityConfigurations())
                .Returns(() => configList);

            Creator = () => new ClassicRules(mockedGame.Object, mockedConfigurationProvider.Object);
        }

        [TestMethod]
        public void If_Calling_SetupEntities__Pawn_List_Should_Not_Be_Empty()
        {
            var rules = Creator();
            rules.SetupEntitites();

            Assert.IsNotNull(pawnListUnderTest.Count);
        }

        [TestMethod]
        public void If_Calling_SetupEntities__Entity_List_Should_Not_Be_Empty()
        {
            var rules = Creator();
            rules.SetupEntitites();

            Assert.IsNotNull(entityListUnderTest.Count);
        }

        [TestMethod]
        public void If_Calling_SetupEntities__Pawn_In_List_Should_Have_Location_As_Defined_By_Configuration()
        {
            var rules = Creator();
            rules.SetupEntitites();

            Assert.AreEqual(3, pawnListUnderTest[0].location);
        }

        [TestMethod]
        public void If_Calling_SetupEntities__Pawn_In_List_Should_Have_Color_As_Defined_By_Configuration()
        {
            var rules = Creator();
            rules.SetupEntitites();

            Assert.AreEqual(2, pawnListUnderTest[0].color);
        }

        [TestMethod]
        public void If_Calling_SetupEntities__Pawn_In_List_Should_Have_PlayerID_As_Defined_By_Configuration()
        {
            var rules = Creator();
            rules.SetupEntitites();

            Assert.AreEqual(1, pawnListUnderTest[0].playerID);
        }

        [TestMethod]
        public void If_Calling_SetupEntities__Pawn_In_List_Should_Have_Pawn_As_Entity_Type()
        {
            var rules = Creator();
            rules.SetupEntitites();

            Assert.AreEqual(EntityType.Pawn, pawnListUnderTest[0].type);
        }

        [TestMethod]
        public void If_Calling_SetupEntities__Eel_In_List_Should_Have_Bottom_Location_As_Defined_By_Configuration()
        {
            var rules = Creator();
            rules.SetupEntitites();           
            
            Assert.AreEqual(4, entityListUnderTest[0].bottom_location);
        }

        [TestMethod]
        public void If_Calling_SetupEntities__Eel_In_List_Should_Have_Top_Location_As_Defined_By_Configuration()
        {
            var rules = Creator();
            rules.SetupEntitites();

            Assert.AreEqual(15, entityListUnderTest[0].top_location);
        }

        [TestMethod]
        public void If_Calling_SetupEntities__Eel_In_List_Should_Have_Eel_As_Entity_Type()
        {
            var rules = Creator();
            rules.SetupEntitites();

            Assert.AreEqual(EntityType.Eel, entityListUnderTest[0].type);
        }

        [TestMethod]
        public void If_Calling_SetupEntities__Escalator_In_List_Should_Have_Bottom_Location_As_Defined_By_Configuration()
        {
            var rules = Creator();
            rules.SetupEntitites();

            Assert.AreEqual(6, entityListUnderTest[1].bottom_location);
        }

        [TestMethod]
        public void If_Calling_SetupEntities__Escalator_In_List_Should_Have_Top_Location_As_Defined_By_Configuration()
        {
            var rules = Creator();
            rules.SetupEntitites();

            Assert.AreEqual(17, entityListUnderTest[1].top_location);
        }

        [TestMethod]
        public void If_Calling_SetupEntities__Escalator_In_List_Should_Have_Escalator_As_Entity_Type()
        {
            var rules = Creator();
            rules.SetupEntitites();

            Assert.AreEqual(EntityType.Escalator, entityListUnderTest[1].type);
        }

        [TestMethod]
        public void If_Calling_CreateBoard__Board_Should_Be_A_Classic_Board()
        {
            var rules = Creator();
            var result = rules.CreateBoard();
                                            
            Assert.IsTrue(Equals(result));
        }

        [TestMethod]
        public void If_Calling_CreateBoard__Created_Board_Should_Have_Classic_Size()
        {
            var rules = Creator();
            var result = rules.CreateBoard();

            Assert.AreEqual(boardSizeUnderTest, result.size);
        }

        [TestMethod]
        public void If_Calling_CreateBoard__Created_Board_Should_Have_Classic_Max_Size()
        {
            var rules = Creator();
            var result = rules.CreateBoard();

            Assert.AreEqual(boardMaxWidthUnderTest, result.MaxWidth);
        }

        [TestMethod]
        public void If_Calling_CreateBoard__Entity_List_Should_Be_Empty()
        {
            var rules = Creator();
            var result = rules.CreateBoard();
           
            Assert.AreEqual(0, entityListUnderTest.Count);
        }

        [TestMethod]
        public void If_Calling_CreateBoard__Pawn_List_Should_Be_Empty()
        {
            var rules = Creator();
            var result = rules.CreateBoard();
            
            Assert.AreEqual(0, pawnListUnderTest.Count);
        }

        [TestMethod]
        // RollDice should return a nubmer with in the interval
        public void If_Calling_RollDice_CorrectDiceAttribute_Should_Be_True()
        {
           
            var rules = Creator();
            rules.RollDice();

            if (rules.DiceResult >= 1 && rules.DiceResult <= 6)
                correctDice = true;
            else correctDice = false;

            Assert.IsTrue(correctDice);
        }

    }
}