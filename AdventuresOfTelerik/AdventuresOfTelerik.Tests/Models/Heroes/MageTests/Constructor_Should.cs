using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventuresOfTelerik.Models.Hero;
using AdventuresOfTelerik.Models;
using Moq;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;

namespace AdventuresOfTelerik.Tests.Models.Heroes.MageTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenParamKnifeIsNull()
        {
            //Arrange
            var stubStaff = new Mock<IStaff>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Mage(stubStaff.Object, null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenParamStaffIsNull()
        {
            //Arrange
            var stubKnife = new Mock<IKnife>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Mage(null, stubKnife.Object));
        }

        [TestMethod]
        public void ThrowNegativeArgumentException_WhenIntelligenceIsNegative()
        {
            //Arrange
            var stubStaff = new Mock<IStaff>();
            var stubKnife = new Mock<IKnife>();
            var mage = new Mage(stubStaff.Object, stubKnife.Object);

            // Act & Assert
            Assert.ThrowsException<NegativeArgumentException>(() => mage.Intelligence = -10);
        }

        [TestMethod]
        public void InitializeIntelligence_WhenParamIsValid()
        {
            //Arrange
            var intelligence = 20;
            var stubStaff = new Mock<IStaff>();
            var stubKnife = new Mock<IKnife>();
            var mage = new Mage(stubStaff.Object, stubKnife.Object);

            // Act & Assert
            Assert.AreEqual(intelligence, mage.Intelligence);
        }

        [TestMethod]
        public void ThrowNegativeArgumentException_WhenSpecialEnergyIsNegative()
        {
            // Arrange
            var stubStaff = new Mock<IStaff>();
            var stubKnife = new Mock<IKnife>();
            var mage = new Mage(stubStaff.Object, stubKnife.Object);

            // Act & Assert
            Assert.ThrowsException<NegativeArgumentException>(() => mage.SpecialEnergy = -1);
        }

        [TestMethod]
        public void InitializeSpecialEnergy_WhenParamIsValid()
        {
            //Arrange
            var specialEnergy = 120;
            var stubStaff = new Mock<IStaff>();
            var stubKnife = new Mock<IKnife>();
            var mage = new Mage(stubStaff.Object, stubKnife.Object);

            // Act & Assert
            Assert.AreEqual(specialEnergy, mage.SpecialEnergy);
        }

        [TestMethod]
        public void InitializeFirstWeaponBowCorrect()
        {
            //Arrange
            var mockStaff = new Mock<IStaff>();
            var stubKnife = new Mock<IKnife>();
            var mage = new Mage(mockStaff.Object, stubKnife.Object);

            // Act & Assert
            Assert.AreEqual(mockStaff.Object, mage.Weapon);
        }

        [TestMethod]
        public void InitializeSecondWeaponKnifeValid()
        {
            //Arrange
            var stubStaff = new Mock<IStaff>();
            var mockKnife = new Mock<IKnife>();
            var mage = new Mage(stubStaff.Object, mockKnife.Object);

            // Act & Assert
            Assert.AreEqual(mockKnife.Object, mage.WeaponSecond);
        }
    }
}
