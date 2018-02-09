using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventuresOfTelerik.Models.Hero;
using AdventuresOfTelerik.Models;
using Moq;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using System;

namespace AdventuresOfTelerik.Tests.Models.Heroes.WarriorTests
{
    [TestClass]
    public class WarriorTests
    {
        [TestMethod]
        public void Should_Throw_WhenKnifeIsNull()
        {
            //Arrange
            var mockMace = new Mock<IMace>();
            // Act&&Assert
            Assert.ThrowsException<ArgumentException>(() => new Warrior(mockMace.Object, null));
        }

        [TestMethod]
        public void Should_Throw_WhenMaceIsNull()
        {
            //Arrange
            var mockKnife = new Mock<IKnife>();
            // Act&&Assert
            Assert.ThrowsException<ArgumentException>(() => new Warrior(null, mockKnife.Object));
        }

        [TestMethod]
        public void Should_Throw_WhenStrengthIsNegative()
        {
            //Arrange
            var mockMace = new Mock<IMace>();
            var mockKnife = new Mock<IKnife>();
            var warrior = new Warrior(mockMace.Object, mockKnife.Object);
            // Act&&Assert
            Assert.ThrowsException<NegativeArgumentException>(() => warrior.Strength = -11);
        }

        [TestMethod]
        public void Should_InitializeStrengthValid()
        {
            //Arrange
            var strength = 16;
            var mockMace = new Mock<IMace>();
            var mockKnife = new Mock<IKnife>();
            var warrior = new Warrior(mockMace.Object, mockKnife.Object);
            // Act&&Assert
            Assert.AreEqual(strength, warrior.Strength);
        }

        [TestMethod]
        public void Should_Throw_WhenSpecialEnergyIsNegative()
        {
            ///Arrange
            var mockMace = new Mock<IMace>();
            var mockKnife = new Mock<IKnife>();
            var warrior = new Warrior(mockMace.Object, mockKnife.Object);
            // Act&&Assert
            Assert.ThrowsException<NegativeArgumentException>(() => warrior.SpecialEnergy = -19);
        }

        [TestMethod]
        public void Should_InitializeSpecialEnergyValid()
        {
            //Arrange
            var specialEnergy = 131;
            var mockMace = new Mock<IMace>();
            var mockKnife = new Mock<IKnife>();
            var warrior = new Warrior(mockMace.Object, mockKnife.Object);
            // Act&&Assert
            Assert.AreEqual(specialEnergy, warrior.SpecialEnergy);
        }

        [TestMethod]
        public void Should_InitializeFirstWeaponValid()
        {
            //Arrange
            var mockMace = new Mock<IMace>();
            var mockKnife = new Mock<IKnife>();
            var warrior = new Warrior(mockMace.Object, mockKnife.Object);
            // Act&&Assert
            Assert.AreEqual(mockMace.Object, warrior.Weapon);
        }

        [TestMethod]
        public void Should_InitializeSecondWeaponValid()
        {
            //Arrange
            var mockMace = new Mock<IMace>();
            var mockKnife = new Mock<IKnife>();
            var warrior = new Warrior(mockMace.Object, mockKnife.Object);
            // Act&&Assert
            Assert.AreEqual(mockKnife.Object, warrior.WeaponSecond);
        }

        [TestMethod]
        public void Should_Additionalinfo_ReturnCorrectString()
        {
            //Arrange
            var mockMace = new Mock<IMace>();
            var mockKnife = new Mock<IKnife>();
            var warrior = new Warrior(mockMace.Object, mockKnife.Object);
            var expected = $"Special Attack: RageAnger, Fury: {warrior.SpecialEnergy}, Strength: {warrior.Strength}";
            // Act&&Assert
            Assert.AreEqual(expected, warrior.Additionalinfo());
        }

        [TestMethod]
        public void SpecialAttack_Should_ReturnZero_When_SpecialEnergyIsLess40()
        {
            //Arrange
            var mockMace = new Mock<IMace>();
            var mockKnife = new Mock<IKnife>();
            var warrior = new Warrior(mockMace.Object, mockKnife.Object);
            //Act
            warrior.SpecialEnergy = 39;
            // Act&&Assert
            Assert.AreEqual(0, warrior.SpecialAttack());
        }

        [TestMethod]
        public void SpecialAttack_Should_ReturnCorrect_When_SpecialEnergyIsMore40()
        {
            //Arrange
            var mockMace = new Mock<IMace>();
            var mockKnife = new Mock<IKnife>();
            var warrior = new Warrior(mockMace.Object, mockKnife.Object);
            //Act
            warrior.SpecialEnergy = 41;
            // Act&&Assert
            Assert.AreEqual(16, warrior.SpecialAttack());
        }
    }
}
