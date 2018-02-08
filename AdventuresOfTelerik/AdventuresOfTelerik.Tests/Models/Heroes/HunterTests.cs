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
    public class HunterTests
    {
        [TestMethod]
        public void Should_Throw_BaseClassExperimentl()
        {
            //Arrange
            //var mockColor = new Mock<HeroColor>();

            // Act&&Assert
            Assert.ThrowsException<ArgumentException>(() => new Mock<IHero>(HeroColor.darkBlue, null) { CallBase = true });
        }

        [TestMethod]
        public void Should_Throw_WhenKnifeIsNull()
        {
            //Arrange
            var mockBow = new Mock<IBow>();
            // Act&&Assert
            Assert.ThrowsException<ArgumentException>(() => new Hunter(mockBow.Object, null));
        }

        [TestMethod]
        public void Should_Throw_WhenAgilityIsNegative()
        {
            //Arrange
            var mockBow = new Mock<IBow>();
            var mockKnife = new Mock<IKnife>();
            var hunter = new Hunter(mockBow.Object, mockKnife.Object);
            // Act&&Assert
            Assert.ThrowsException<NegativeArgumentException>(() => hunter.Agility = -11);
        }

        [TestMethod]
        public void Should_InitializeAgilityValid()
        {
            //Arrange
            var agility = 15;
            var mockBow = new Mock<IBow>();
            var mockKnife = new Mock<IKnife>();
            var hunter = new Hunter(mockBow.Object, mockKnife.Object);
            // Act&&Assert
            Assert.AreEqual(agility, hunter.Agility);
        }

        [TestMethod]
        public void Should_Throw_WhenSpecialEnergyIsNegative()
        {
            ///Arrange
            var mockBow = new Mock<IBow>();
            var mockKnife = new Mock<IKnife>();
            var hunter = new Hunter(mockBow.Object, mockKnife.Object);
            // Act&&Assert
            Assert.ThrowsException<NegativeArgumentException>(() => hunter.SpecialEnergy = -19);
        }

        [TestMethod]
        public void Should_InitializeSpecialEnergyValid()
        {
            //Arrange
            var specialEnergy = 150;
            var mockBow = new Mock<IBow>();
            var mockKnife = new Mock<IKnife>();
            var hunter = new Hunter(mockBow.Object, mockKnife.Object);
            // Act&&Assert
            Assert.AreEqual(specialEnergy, hunter.SpecialEnergy);
        }

        [TestMethod]
        public void Should_InitializeFirstWeaponValid()
        {
            //Arrange
            var mockBow = new Mock<IBow>();
            var mockKnife = new Mock<IKnife>();
            var hunter = new Hunter(mockBow.Object, mockKnife.Object);
            // Act&&Assert
            Assert.AreEqual(mockBow.Object, hunter.Weapon);
        }

        [TestMethod]
        public void Should_InitializeSecondWeaponValid()
        {
            
            //Arrange
            var mockBow = new Mock<IBow>();
            var mockKnife = new Mock<IKnife>();
            var hunter = new Hunter(mockBow.Object, mockKnife.Object);
            // Act&&Assert
            Assert.AreEqual(mockKnife.Object, hunter.WeaponSecond);
        }

        [TestMethod]
        public void Should_Additionalinfo_ReturnCorrectString()
        {
            //Arrange
            var mockBow = new Mock<IBow>();
            var mockKnife = new Mock<IKnife>();
            var hunter = new Hunter(mockBow.Object, mockKnife.Object);
            var expected =  $"Special Attack: FocusShot, Energy: {hunter.SpecialEnergy}, Agility: {hunter.Agility}";
            // Act&&Assert
            Assert.AreEqual(expected, hunter.Additionalinfo());
        }

        [TestMethod]
        public void ShouldSpecialAttack_ReturnZero_When_SpecialEnergyIsLess44()
        {
            //Arrange
            var mockBow = new Mock<IBow>();
            var mockKnife = new Mock<IKnife>();
            var hunter = new Hunter(mockBow.Object, mockKnife.Object);
            //Act
            hunter.SpecialEnergy = 4;
            // Act&&Assert
            Assert.AreEqual(0, hunter.SpecialAttack());
        }

        [TestMethod]
        public void ShouldSpecialAttack_ReturnCorrect_When_SpecialEnergyIsMore44()
        {
            //Arrange
            var mockBow = new Mock<IBow>();
            var mockKnife = new Mock<IKnife>();
            var hunter = new Hunter(mockBow.Object, mockKnife.Object);
            //Act
            hunter.SpecialEnergy = 66;
            // Act&&Assert
            Assert.AreEqual(15, hunter.SpecialAttack());
        }
    }
}
