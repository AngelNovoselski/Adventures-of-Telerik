using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventuresOfTelerik.Models.Hero;
using AdventuresOfTelerik.Models;
using Moq;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Common.Enums;

namespace AdventuresOfTelerik.Tests.Models.Hero
{
    [TestClass]
    public class MageTests
    {


        [TestMethod]
        public void Should_Throw_WhenKnifeIsNull()
        {
            //Arrange
            var mockStaff = new Mock<IStaff>();
            // Act&&Assert
            Assert.ThrowsException<ArgumentException>(() => new Mage(mockStaff.Object, null));
        }

        [TestMethod]
        public void Should_Throw_WhenStaffIsNull()
        {
            //Arrange
            var mockKnife = new Mock<IKnife>();
            // Act&&Assert
            Assert.ThrowsException<ArgumentException>(() => new Mage(null, mockKnife.Object));
        }

        [TestMethod]
        public void Should_Throw_WhenIntelligenceIsNegative()
        {
            //Arrange
            var mockStaff = new Mock<IStaff>();
            var mockKnife = new Mock<IKnife>();
            var mage = new Mage(mockStaff.Object, mockKnife.Object);
            // Act&&Assert
            Assert.ThrowsException<NegativeArgumentException>(() => mage.Intelligence = -10);
        }

        [TestMethod]
        public void Should_InitializeIntelligenceValid()
        {
            //Arrange
            var intelligence = 20;
            var mockStaff = new Mock<IStaff>();
            var mockKnife = new Mock<IKnife>();
            var mage = new Mage(mockStaff.Object, mockKnife.Object);
            // Act&&Assert
            Assert.AreEqual(intelligence, mage.Intelligence);
        }

        [TestMethod]
        public void Should_Throw_WhenSpecialEnergyIsNegative()
        {
            ///Arrange
            var mockStaff = new Mock<IStaff>();
            var mockKnife = new Mock<IKnife>();
            var mage = new Mage(mockStaff.Object, mockKnife.Object);
            // Act&&Assert
            Assert.ThrowsException<NegativeArgumentException>(() => mage.SpecialEnergy = -1);
        }

        [TestMethod]
        public void Should_InitializeSpecialEnergyValid()
        {
            //Arrange
            var specialEnergy = 120;
            var mockStaff = new Mock<IStaff>();
            var mockKnife = new Mock<IKnife>();
            var mage = new Mage(mockStaff.Object, mockKnife.Object);
            // Act&&Assert
            Assert.AreEqual(specialEnergy, mage.SpecialEnergy);
        }

        [TestMethod]
        public void Should_InitializeFirstWeaponValid()
        {
            //Arrange
            var mockStaff = new Mock<IStaff>();
            var mockKnife = new Mock<IKnife>();
            var mage = new Mage(mockStaff.Object, mockKnife.Object);
            // Act&&Assert
            Assert.AreEqual(mockStaff.Object, mage.Weapon);
        }

        [TestMethod]
        public void Should_InitializeSecondWeaponValid()
        {
            //Arrange
            var mockStaff = new Mock<IStaff>();
            var mockKnife = new Mock<IKnife>();
            var mage = new Mage(mockStaff.Object, mockKnife.Object);
            // Act&&Assert
            Assert.AreEqual(mockKnife.Object, mage.WeaponSecond);
        }

        [TestMethod]
        public void Should_Additionalinfo_ReturnCorrectString()
        {
            //Arrange
            var mockStaff = new Mock<IStaff>();
            var mockKnife = new Mock<IKnife>();
            var mage = new Mage(mockStaff.Object, mockKnife.Object);
            var expected = $"Special Attack: CastSpell, Mana: {mage.SpecialEnergy}, Intelligence: {mage.Intelligence}";
            // Act&&Assert
            Assert.AreEqual(expected, mage.Additionalinfo());
        }

        [TestMethod]
        public void SpecialAttack_Should_ReturnZero_When_SpecialEnergyIsLess35()
        {
            //Arrange
            var mockStaff = new Mock<IStaff>();
            var mockKnife = new Mock<IKnife>();
            var mage = new Mage(mockStaff.Object, mockKnife.Object);
            //Act
            mage.SpecialEnergy = 34;
            // Act&&Assert
            Assert.AreEqual(0, mage.SpecialAttack());
        }

        [TestMethod]
        public void SpecialAttack_Should_ReturnCorrect_When_SpecialEnergyIsMore35()
        {
            //Arrange
            var mockStaff = new Mock<IStaff>();
            var mockKnife = new Mock<IKnife>();
            var mage = new Mage(mockStaff.Object, mockKnife.Object);
            //Act
            mage.SpecialEnergy = 36;
            // Act&&Assert
            Assert.AreEqual(20, mage.SpecialAttack());
        }
    }
}
