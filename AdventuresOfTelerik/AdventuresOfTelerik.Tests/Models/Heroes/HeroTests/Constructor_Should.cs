using AdventuresOfTelerik.Common.Enums;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Tests.Models.Heroes.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AdventuresOfTelerik.Tests.Models.Heroes.HeroTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenParamPassedSecondKnifeIsNull()
        {
            // Arrange
            var color = HeroColor.red;
            var stubKnife = new Mock<IKnife>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new FakeAbstractHero(color, null));
        }

        [TestMethod]
        public void SetCorrectHeroColor_WhenParamsAreValid()
        {
            // Arrange
            var color = HeroColor.red;
            var stubKnife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, stubKnife.Object);

            // Act & Assert
            Assert.AreEqual(color, fakeHero.HeroColor);
        }

        [TestMethod]
        public void SetCorrectKnife_WhenParamsAreValid()
        {
            // Arrange
            var color = HeroColor.red;
            var mockKnife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, mockKnife.Object);

            // Act & Assert
            Assert.AreEqual(mockKnife.Object, fakeHero.WeaponSecond);
        }

        [TestMethod]
        public void SetCorrectData_WhenParamsAreValid()
        {
            // Arrange
            var color = HeroColor.red;
            var stubKnife = new Mock<IKnife>();

            // Act
            var fakeHero = new FakeAbstractHero(color, stubKnife.Object);

            // Assert
            Assert.AreEqual("Telerik", fakeHero.Name);
            Assert.AreEqual(1, fakeHero.PositionX);
            Assert.AreEqual(1, fakeHero.PositionY);
            Assert.AreEqual(450, fakeHero.Hp);
            Assert.AreEqual(1, fakeHero.Level);
            Assert.AreEqual(0, fakeHero.Exp);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenParamWeaponIsNull()
        {
            // Arrange
            var color = HeroColor.red;
            var stubKnife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, stubKnife.Object);

            // Act &  Assert
            Assert.ThrowsException<ArgumentNullException>(() => fakeHero.Weapon = null);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenParamSecondWeaponIsNull()
        {
            // Arrange
            var color = HeroColor.red;
            var stubKnifeife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, stubKnifeife.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => fakeHero.WeaponSecond = null);
        }
    }
}
