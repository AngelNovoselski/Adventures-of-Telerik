using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventuresOfTelerik.Engine;
using Moq;
using AdventuresOfTelerik.Factories;
using AdventuresOfTelerik.Models;
using AdventuresOfTelerik.Models.MessagesForPrinting;
using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.HeroInterfaces;

namespace AdventuresOfTelerik.Tests.Engine
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenFactoryIsNull()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(
                () => new GameEngine(null, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenScreenPrinterIsNull()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(
                () => new GameEngine(stubFactory.Object, null, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenHeroPrinterIsNull()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(
                () => new GameEngine(stubFactory.Object, stubScreenPrinter.Object, null,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenFightModeIsNull()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(
                () => new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                null, stubCollisionDetector.Object, stubCommandSelection.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCollisionDetectorIsNull()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(
                () => new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, null, stubCommandSelection.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCommandSelectionIsNull()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(
                () => new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, null));
        }

        [TestMethod]
        //[Ignore]
        public void InvokeCreateOnFactoryHeroFactoryCreation()
        {
            // Arrange
            var mockFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            // Act
            stubScreenPrinter.Setup(x => x.Logger.SetSize());
            var engine = new GameEngine(mockFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            mockFactory.Verify(x => x.HeroFactory(), Times.Exactly(1));
        }

        [TestMethod]
        public void InvokePrinterLoggerSetSizeOnCreation()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var mockScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            // Act
            mockScreenPrinter.Setup(x => x.Logger.SetSize());
            var engine = new GameEngine(stubFactory.Object, mockScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            mockScreenPrinter.Verify(x => x.Logger.SetSize(), Times.Exactly(1));
        }

        [TestMethod]
        public void SetProperFactory_WhenEngineIsCreated()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var mockScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            // Act
            mockScreenPrinter.Setup(x => x.Logger.SetSize());
            var engine = new GameEngine(stubFactory.Object, mockScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            Assert.AreEqual(stubFactory.Object, engine.Factory);
        }

        [TestMethod]
        public void SetProperPrinter_WhenEngineIsCreated()
        {
            // Arrange & Act
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());
            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            Assert.AreEqual(stubScreenPrinter.Object, engine.Printer);
        }

        [TestMethod]
        public void SetProperHeroPrint_WhenEngineIsCreated()
        {
            // Arrange & Act
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());
            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            Assert.AreEqual(stubHeroPrinter.Object, engine.HeroPrint);
        }

        [TestMethod]
        public void SetProperFightMode_WhenEngineIsCreated()
        {
            // Arrange & Act
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());
            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            Assert.AreEqual(stubFightMode.Object, engine.FightMode);
        }

        [TestMethod]
        public void SetProperDetect_WhenEngineIsCreated()
        {
            // Arrange & Act
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());
            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            Assert.AreEqual(stubCollisionDetector.Object, engine.Detect);
        }

        [TestMethod]
        public void SetProperCommandSelection_WhenEngineIsCreated()
        {
            // Arrange & Act
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());
            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            Assert.AreEqual(stubCommandSelection.Object, engine.CommandSelection);
        }

        [TestMethod]
        public void ThrowNullReferenceException_WhenMapIsNull()
        {
            // Arrange & Act
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());
            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            Assert.ThrowsException<NullReferenceException>(() => engine.Map = null);
        }

        [TestMethod]
        public void ThrowNullReferenceException_WhenHeroIsNull()
        {
            // Arrange & Act
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());
            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            Assert.ThrowsException<NullReferenceException>(() => engine.Hero = null);
        }

        [TestMethod]
        public void ThrowNullReferenceException_WhenHeroCordIsNull()
        {
            // Arrange & Act
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());
            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            Assert.ThrowsException<NullReferenceException>(() => engine.HeroCord = null);
        }

        [TestMethod]
        public void InvokeOnePrintStartScreen_WhenEngineIsStarted()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var mockScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            mockScreenPrinter.Setup(x => x.Logger.SetSize());
            mockScreenPrinter.Setup(x => x.PrintChooseHeroScreen()).Returns("mage");

            var map = new Mock<IMap>();
            stubFactory.Setup(x => x.CreateMap()).Returns(map.Object);

            var hero = new Mock<IHero>();
            string type = "mage";
            stubFactory.Setup(x => x.GetHeroBasedOnType(type)).Returns(hero.Object);

            var heroCord = new Mock<IHeroCoordinates>();
            stubFactory.Setup(x => x.CreateHeroCoordinates(hero.Object)).Returns(heroCord.Object);
            

            var engine = new GameEngine(stubFactory.Object, mockScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Act
            engine.Start();

            // Assert
            mockScreenPrinter.Verify(x => x.PrintStartScreen(), Times.Exactly(1));
            mockScreenPrinter.Verify(x => x.PrintAfterChoiceScreen(), Times.Exactly(1));
            mockScreenPrinter.Verify(x => x.PrintChooseHeroScreen(), Times.Exactly(1));
        }
    }
}
