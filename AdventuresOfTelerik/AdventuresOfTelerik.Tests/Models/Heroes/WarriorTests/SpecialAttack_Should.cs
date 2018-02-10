using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Models.Hero;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventuresOfTelerik.Tests.Models.Heroes.WarriorTests
{
    [TestClass]
    public class SpecialAttack_Should
    {
        [TestMethod]
        public void ReturnZero_SpecialEnergyIsLessThan40()
        {
            //Arrange
            var stubMace = new Mock<IMace>();
            var stubKnife = new Mock<IKnife>();
            var warrior = new Warrior(stubMace.Object, stubKnife.Object);
            warrior.SpecialEnergy = 39;

            // Act & Assert
            Assert.AreEqual(0, warrior.SpecialAttack());
        }

        [TestMethod]
        public void ReturnCorrectValue_WhenSpecialEnergyIsMoreThan40()
        {
            //Arrange
            var stubMace = new Mock<IMace>();
            var stubKnife = new Mock<IKnife>();
            var warrior = new Warrior(stubMace.Object, stubKnife.Object);
            warrior.SpecialEnergy = 41;
            var warriorStregthValue = 16;

            // Act & Assert
            Assert.AreEqual(warriorStregthValue, warrior.SpecialAttack());
        }
    }
}
