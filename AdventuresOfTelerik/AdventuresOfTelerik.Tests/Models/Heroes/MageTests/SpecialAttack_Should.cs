using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Models.Hero;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventuresOfTelerik.Tests.Models.Heroes.MageTests
{
    [TestClass]
    public class SpecialAttack_Should
    {
        [TestMethod]
        public void ReturnZero_WhenSpecialEnergyIsLessThan35()
        {
            //Arrange
            var mockStaff = new Mock<IStaff>();
            var mockKnife = new Mock<IKnife>();
            var mage = new Mage(mockStaff.Object, mockKnife.Object);
            mage.SpecialEnergy = 34;

            // Act & Assert
            Assert.AreEqual(0, mage.SpecialAttack());
        }

        [TestMethod]
        public void ReturnCorrectValue_WhenSpecialEnergyIsMoreThan35()
        {
            //Arrange
            var stubStaff = new Mock<IStaff>();
            var stubKnife = new Mock<IKnife>();
            var mage = new Mage(stubStaff.Object, stubKnife.Object);
            mage.SpecialEnergy = 36;
            var mageIntelligenceValue = 20;

            // Act & Assert
            Assert.AreEqual(mageIntelligenceValue, mage.SpecialAttack());
        }
    }
}
