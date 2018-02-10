using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventuresOfTelerik.Models.Hero;
using AdventuresOfTelerik.Models;
using Moq;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;

namespace AdventuresOfTelerik.Tests.Models.Heroes.HunterTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenParamKnifeIsNull()
        {
            // Arrange
            var stubBow = new Mock<IBow>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Hunter(stubBow.Object, null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenParamBowIsNull()
        {
            // Arrange
            var stubKnife = new Mock<IKnife>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Hunter(null, stubKnife.Object));
        }

        [TestMethod]
        public void ThrowNegativeArgumentException_WhenAgilityIsNegative()
        {
            // Arrange
            var stubBow = new Mock<IBow>();
            var stubKnife = new Mock<IKnife>();
            var hunter = new Hunter(stubBow.Object, stubKnife.Object);

            // Act & Assert
            Assert.ThrowsException<NegativeArgumentException>(() => hunter.Agility = -11);
        }

        [TestMethod]
        public void ThrowCorrectMessage_WhenAgilityIsNegative()
        {
            // Arrange
            var stubBow = new Mock<IBow>();
            var stubKnife = new Mock<IKnife>();
            var hunter = new Hunter(stubBow.Object, stubKnife.Object);
            var expectedMessage = "Agility must be positive number!!!";

            // Act
            var exception = Assert.ThrowsException<NegativeArgumentException>(() => hunter.Agility = -11);
            var actualMessage = exception.Message;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ThrowCorrectMessage_WhenSpecialEnergyIsNegative()
        {
            // Arrange
            var stubBow = new Mock<IBow>();
            var stubKnife = new Mock<IKnife>();
            var hunter = new Hunter(stubBow.Object, stubKnife.Object);
            var expectedMessage = "Energy must be positive number!!!";

            // Act
            var exception = Assert.ThrowsException<NegativeArgumentException>(() => hunter.SpecialEnergy = -19);
            var actualMessage = exception.Message;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void InitializeAgility_WhenParamIsValid()
        {
            // Arrange
            var agility = 15;
            var stubBow = new Mock<IBow>();
            var stubKnife = new Mock<IKnife>();
            var hunter = new Hunter(stubBow.Object, stubKnife.Object);

            // Act & Assert
            Assert.AreEqual(agility, hunter.Agility);
        }

        [TestMethod]
        public void ThrowNegativeArgumentException_WhenSpecialEnergyIsNegative()
        {
            // Arrange
            var stubBow = new Mock<IBow>();
            var stubKnife = new Mock<IKnife>();
            var hunter = new Hunter(stubBow.Object, stubKnife.Object);

            // Act & Assert
            Assert.ThrowsException<NegativeArgumentException>(() => hunter.SpecialEnergy = -19);
        }

        [TestMethod]
        public void InitializeSpecialEnergy_WhenParamIsValid()
        {
            // Arrange
            var specialEnergy = 150;
            var stubBow = new Mock<IBow>();
            var stubKnife = new Mock<IKnife>();
            var hunter = new Hunter(stubBow.Object, stubKnife.Object);

            // Act & Assert
            Assert.AreEqual(specialEnergy, hunter.SpecialEnergy);
        }

        [TestMethod]
        public void InitializeFirstWeaponBowCorrect()
        {
            // Arrange
            var mockBow = new Mock<IBow>();
            var stubKnife = new Mock<IKnife>();
            var hunter = new Hunter(mockBow.Object, stubKnife.Object);

            // Act & Assert
            Assert.AreEqual(mockBow.Object, hunter.Weapon);
        }

        [TestMethod]
        public void InitializeSecondWeaponKnifeValid()
        {
            // Arrange
            var stubBow = new Mock<IBow>();
            var mockKnife = new Mock<IKnife>();
            var hunter = new Hunter(stubBow.Object, mockKnife.Object);

            // Act & Assert
            Assert.AreEqual(mockKnife.Object, hunter.WeaponSecond);
        }
    }
}
