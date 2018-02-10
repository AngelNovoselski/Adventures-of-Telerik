using System;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Models.Hero;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventuresOfTelerik.Tests.Models.Heroes.WarriorTests
{
    [TestClass]
    public class AdditionalInfo_Should
    {
        [TestMethod]
        public void ReturnCorrectMessage_WithCorrectProperties()
        {
            //Arrange
            var stubMace = new Mock<IMace>();
            var stubKnife = new Mock<IKnife>();
            var warrior = new Warrior(stubMace.Object, stubKnife.Object);
            var expected = $"Special Attack: RageAnger, Fury: {warrior.SpecialEnergy}, Strength: {warrior.Strength}";

            // Act & Assert
            Assert.AreEqual(expected, warrior.Additionalinfo());
        }
    }
}
