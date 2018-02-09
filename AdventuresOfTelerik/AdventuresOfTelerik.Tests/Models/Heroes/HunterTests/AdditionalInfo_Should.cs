using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Models.Hero;

namespace AdventuresOfTelerik.Tests.Models.Heroes.HunterTests
{
    [TestClass]
    public class AdditionalInfo_Should
    {
        [TestMethod]
        public void ReturnCorrectMessage_WithCorrectProperties()
        {
            // Arrange
            var stubBow = new Mock<IBow>();
            var stubKnife = new Mock<IKnife>();
            var hunter = new Hunter(stubBow.Object, stubKnife.Object);
            var expected = $"Special Attack: FocusShot, Energy: {hunter.SpecialEnergy}, Agility: {hunter.Agility}";

            // Act & Assert
            Assert.AreEqual(expected, hunter.Additionalinfo());
        }
    }
}
