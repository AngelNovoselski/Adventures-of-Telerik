using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Engine;
using AdventuresOfTelerik.Factories;
using AdventuresOfTelerik.Models;
using AdventuresOfTelerik.Models.MessagesForPrinting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventuresOfTelerik.Tests.Engine
{
    [TestClass]
    public class Start_Should
    {
        [TestMethod]
        public void InvokeOneTimeEachPrintScreen()
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

        [TestMethod]
        public void InvokeOneFactoryCreateMaAndGetHeroBasedOnTypeAndCreateHeroCoordinates()
        {
            // Arrange
            var mockFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var stubCommandSelection = new Mock<ICommandSelection>();

            stubScreenPrinter.Setup(x => x.Logger.SetSize());
            stubScreenPrinter.Setup(x => x.PrintChooseHeroScreen()).Returns("mage");

            var map = new Mock<IMap>();
            mockFactory.Setup(x => x.CreateMap()).Returns(map.Object);

            var hero = new Mock<IHero>();
            string type = "mage";
            mockFactory.Setup(x => x.GetHeroBasedOnType(type)).Returns(hero.Object);

            var heroCord = new Mock<IHeroCoordinates>();
            mockFactory.Setup(x => x.CreateHeroCoordinates(hero.Object)).Returns(heroCord.Object);

            var engine = new GameEngine(mockFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, stubCommandSelection.Object);

            // Act
            engine.Start();

            // Assert
            mockFactory.Verify(x => x.CreateMap(), Times.Exactly(1));
            mockFactory.Verify(x => x.GetHeroBasedOnType(type), Times.Exactly(1));
            mockFactory.Verify(x => x.CreateHeroCoordinates(hero.Object), Times.Exactly(1));
        }

        [TestMethod]
        public void InvokeOneCommandSelectionReadCommands()
        {
            // Arrange
            var stubFactory = new Mock<IGameFactory>();
            var stubScreenPrinter = new Mock<IScreenPrinter>();
            var stubHeroPrinter = new Mock<IHeroPrinter>();
            var stubFightMode = new Mock<IFightMode>();
            var stubCollisionDetector = new Mock<ICollisionDetector>();
            var mockCommandSelection = new Mock<ICommandSelection>();

            stubScreenPrinter.Setup(x => x.Logger.SetSize());
            stubScreenPrinter.Setup(x => x.PrintChooseHeroScreen()).Returns("mage");

            var map = new Mock<IMap>();
            stubFactory.Setup(x => x.CreateMap()).Returns(map.Object);

            var hero = new Mock<IHero>();
            string type = "mage";
            stubFactory.Setup(x => x.GetHeroBasedOnType(type)).Returns(hero.Object);

            var heroCord = new Mock<IHeroCoordinates>();
            stubFactory.Setup(x => x.CreateHeroCoordinates(hero.Object)).Returns(heroCord.Object);

            var engine = new GameEngine(stubFactory.Object, stubScreenPrinter.Object, stubHeroPrinter.Object,
                stubFightMode.Object, stubCollisionDetector.Object, mockCommandSelection.Object);

            // Act
            engine.Start();

            // Assert
            mockCommandSelection.Verify(x => x.ReadCommands(hero.Object, map.Object, stubFactory.Object, 
                stubScreenPrinter.Object.Logger, stubHeroPrinter.Object, stubFightMode.Object, 
                stubCollisionDetector.Object, heroCord.Object), Times.Exactly(1));
        }
    }
}
