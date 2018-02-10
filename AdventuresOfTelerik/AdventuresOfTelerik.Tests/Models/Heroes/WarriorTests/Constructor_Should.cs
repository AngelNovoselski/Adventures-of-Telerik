using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventuresOfTelerik.Models.Hero;
using AdventuresOfTelerik.Models;
using Moq;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;

namespace AdventuresOfTelerik.Tests.Models.Heroes.WarriorTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenParamKnifeIsNull()
        {
            // Arrange
            var stubMace = new Mock<IMace>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Warrior(stubMace.Object, null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenParamMaceIsNull()
        {
            // Arrange
            var stubKnife = new Mock<IKnife>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Warrior(null, stubKnife.Object));
        }

        [TestMethod]
        public void ThrowNegativeArgumentException__WhenStrengthIsNegative()
        {
            // Arrange
            var stubMace = new Mock<IMace>();
            var stubKnife = new Mock<IKnife>();
            var warrior = new Warrior(stubMace.Object, stubKnife.Object);

            // Act & Assert
            Assert.ThrowsException<NegativeArgumentException>(() => warrior.Strength = -11);
        }

        [TestMethod]
        public void InitializeStrnth_WhenParamIsValid()
        {
            // Arrange
            var strength = 16;
            var stubMace = new Mock<IMace>();
            var stubKnife = new Mock<IKnife>();
            var warrior = new Warrior(stubMace.Object, stubKnife.Object);

            // Act & Assert
            Assert.AreEqual(strength, warrior.Strength);
        }

        [TestMethod]
        public void ThrowNegativeArgumentException_WhenSpecialEnergyIsNegative()
        {
            // Arrange
            var stubMace = new Mock<IMace>();
            var stubKnife = new Mock<IKnife>();
            var warrior = new Warrior(stubMace.Object, stubKnife.Object);

            // Act & Assert
            Assert.ThrowsException<NegativeArgumentException>(() => warrior.SpecialEnergy = -19);
        }

        [TestMethod]
        public void InitializeSpecialEnergy_WhenParamIsValid()
        {
            //Arrange
            var specialEnergy = 131;
            var stubMace = new Mock<IMace>();
            var stubKnife = new Mock<IKnife>();
            var warrior = new Warrior(stubMace.Object, stubKnife.Object);

            // Act & Assert
            Assert.AreEqual(specialEnergy, warrior.SpecialEnergy);
        }

        [TestMethod]
        public void InitializeFirstWeaponBowCorrect()
        {
            //Arrange
            var mockMace = new Mock<IMace>();
            var stubKnife = new Mock<IKnife>();
            var warrior = new Warrior(mockMace.Object, stubKnife.Object);

            // Act & Assert
            Assert.AreEqual(mockMace.Object, warrior.Weapon);
        }

        [TestMethod]
        public void InitializeSecondWeaponKnifeValid()
        {
            //Arrange
            var stubMace = new Mock<IMace>();
            var mockKnife = new Mock<IKnife>();
            var warrior = new Warrior(stubMace.Object, mockKnife.Object);

            // Act & Assert
            Assert.AreEqual(mockKnife.Object, warrior.WeaponSecond);
        }
    }
}
