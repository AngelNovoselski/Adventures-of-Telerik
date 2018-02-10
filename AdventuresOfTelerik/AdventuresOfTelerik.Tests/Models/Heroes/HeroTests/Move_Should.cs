using AdventuresOfTelerik.Common.Enums;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Tests.Models.Heroes.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventuresOfTelerik.Tests.Models.Heroes.HeroTests
{
    [TestClass]
    public class Move_Should
    {
        [TestMethod]
        public void SetCorrectNewValues_WhenMovingLeft()
        {
            // Arrange
            var left = 1;
            var color = HeroColor.red;
            var stubKnife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, stubKnife.Object);
            var currentPosition = fakeHero.PositionY;

            // Act
            fakeHero.Move(left);

            // Assert
            Assert.AreEqual(currentPosition - 1, fakeHero.PositionY);
        }

        [TestMethod]
        public void SetCorrectNewValues_WhenMovingRight()
        {
            // Arrange
            var right = 2;
            var color = HeroColor.red;
            var stubKnife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, stubKnife.Object);
            var currentPosition = fakeHero.PositionY;

            // Act
            fakeHero.Move(right);

            // Assert
            Assert.AreEqual(currentPosition + 1, fakeHero.PositionY);
        }

        [TestMethod]
        public void SetCorrectNewValues_When_MovingUp()
        {
            //arrange
            var up = 3;
            var color = HeroColor.red;
            var stubKnife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, stubKnife.Object);
            var currentPosition = fakeHero.PositionX;

            // Act
            fakeHero.Move(up);

            // Assert
            Assert.AreEqual(currentPosition - 1, fakeHero.PositionX);
        }

        [TestMethod]
        public void SetCorrectNewValues_When_MovingDown()
        {
            // Arrange
            var down = 4;
            var color = HeroColor.red;
            var stubKnife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, stubKnife.Object);
            var currentPosition = fakeHero.PositionX;

            // Act
            fakeHero.Move(down);

            // Assert
            Assert.AreEqual(currentPosition + 1, fakeHero.PositionX);
        }
    }
}
