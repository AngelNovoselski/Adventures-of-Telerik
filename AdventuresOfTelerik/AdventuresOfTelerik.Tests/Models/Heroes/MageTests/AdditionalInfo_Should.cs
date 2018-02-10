using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Models.Hero;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventuresOfTelerik.Tests.Models.Heroes.MageTests
{
    [TestClass]
    public class AdditionalInfo_Should
    {
        [TestMethod]
        public void ReturnCorrectMessage_WithCorrectProperties()
        {
            // Arrange
            var mockStaff = new Mock<IStaff>();
            var mockKnife = new Mock<IKnife>();
            var mage = new Mage(mockStaff.Object, mockKnife.Object);
            var expected = $"Special Attack: CastSpell, Mana: {mage.SpecialEnergy}, Intelligence: {mage.Intelligence}";

            // Act & Assert
            Assert.AreEqual(expected, mage.Additionalinfo());
        }
    }
}
