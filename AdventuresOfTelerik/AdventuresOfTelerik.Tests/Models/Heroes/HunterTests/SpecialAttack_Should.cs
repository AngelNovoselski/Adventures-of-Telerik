using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Models.Hero;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventuresOfTelerik.Tests.Models.Heroes.HunterTests
{
    [TestClass]
    public class SpecialAttack_Should
    {
        [TestMethod]
        public void ReturnZero_WhenSpecialEnergyIsLessThan44()
        {
            // Arrange
            var stubBow = new Mock<IBow>();
            var stubKnife = new Mock<IKnife>();
            var hunter = new Hunter(stubBow.Object, stubKnife.Object);
            hunter.SpecialEnergy = 4;

            // Act & Assert
            Assert.AreEqual(0, hunter.SpecialAttack());
        }

        [TestMethod]
        public void ReturnCorrectValue_When_SpecialEnergyIsMoreThan44()
        {
            // Arrange
            var stubBow = new Mock<IBow>();
            var stubKnife = new Mock<IKnife>();
            var hunter = new Hunter(stubBow.Object, stubKnife.Object);
            hunter.SpecialEnergy = 66;
            var hunterAgilityValue = 15;

            // Act & Assert
            Assert.AreEqual(hunterAgilityValue, hunter.SpecialAttack());
        }
    }
}
