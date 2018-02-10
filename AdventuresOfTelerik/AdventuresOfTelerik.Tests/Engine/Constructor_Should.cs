using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventuresOfTelerik.Engine;
using Moq;
using AdventuresOfTelerik.Factories;
using AdventuresOfTelerik.Models;
using AdventuresOfTelerik.Models.MessagesForPrinting;

namespace AdventuresOfTelerik.Tests.Engine
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenPassedParamFactoryIsNull()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new GameEngine(null, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenPassedParamScreenPrinterIsNull()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new GameEngine(stubFactory.Object, null, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenPassedParamHeroPrinterIsNull()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new GameEngine(stubFactory.Object, stubScreenPrinter.Object, null,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenPassedParamFightModeIsNull()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                null, stubCollisionDetector.Object, stubCommandSelection.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenPassedParamCollisionDetectorIsNull()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, null, stubCommandSelection.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenPassedParamCommandSelectionIsNull()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, null));
        }

        [TestMethod]
        public void InvokeFactoryHeroFactory()
        {
            // Arrange
            var mockFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());

            // Act
            var engine = new GameEngine(mockFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            mockFactory.Verify(x => x.HeroFactory(), Times.Exactly(1));
        }

        [TestMethod]
        public void InvokePrinterLoggerSetSize()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var mockScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            mockScreenPrinter.Setup(x => x.Logger.SetSize());

            // Act
            var engine = new GameEngine(stubFactory.Object, mockScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            mockScreenPrinter.Verify(x => x.Logger.SetSize(), Times.Exactly(1));
        }

        [TestMethod]
        public void SetCorrectFactory_WhenEngineIsCreated()
        {
            // Arrange
            var mockFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());

            // Act
            var engine = new GameEngine(mockFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            Assert.AreEqual(mockFactory.Object, engine.Factory);
        }

        [TestMethod]
        public void SetCorrectScreenPrinter_WhenEngineIsCreated()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var mockScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            mockScreenPrinter.Setup(x => x.Logger.SetSize());

            // Act
            var engine = new GameEngine(stubFactory.Object, mockScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            Assert.AreEqual(mockScreenPrinter.Object, engine.Printer);
        }

        [TestMethod]
        public void SetCorrectHeroPrinter_WhenEngineIsCreated()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var mockHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());

            // Act
            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, mockHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            Assert.AreEqual(mockHeroPrinter.Object, engine.HeroPrint);
        }

        [TestMethod]
        public void SetCorrectFightMode_WhenEngineIsCreated()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var mockFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());

            // Act
            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                mockFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            Assert.AreEqual(mockFightMode.Object, engine.FightMode);
        }

        [TestMethod]
        public void SetCorrectCollisionDetector_WhenEngineIsCreated()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var mockCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());

            // Act
            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, mockCollisionDetector.Object, stubCommandSelection.Object);

            // Assert
            Assert.AreEqual(mockCollisionDetector.Object, engine.Detect);
        }

        [TestMethod]
        public void SetCorrectCommandSelection_WhenEngineIsCreated()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var mockCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());

            // Act
            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, mockCommandSelection.Object);

            // Assert
            Assert.AreEqual(mockCommandSelection.Object, engine.CommandSelection);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMapIsNull()
        {
            // Arrange 
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());
            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => engine.Map = null);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenHeroIsNull()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());
            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => engine.Hero = null);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenHeroCordIsNull()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();
            stubScreenPrinter.Setup(x => x.Logger.SetSize());
            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => engine.HeroCord = null);
        }
    }
}
