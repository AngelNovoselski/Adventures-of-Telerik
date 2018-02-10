using AdventuresOfTelerik.Common.Enums;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Tests.Models.Heroes.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventuresOfTelerik.Tests.Models.Heroes.HeroTests
{
    [TestClass]
    public class ToString_Should
    {
        [TestMethod]
        public void ToStringReturnCorrectInfo()
        {
            // Arrange
            var color = HeroColor.red;
            var stubKnife = new Mock<IKnife>();
            var stubWeapon = new Mock<IWeapon>();
            var fakeHero = new FakeAbstractHero(color, stubKnife.Object);
            fakeHero.Weapon = stubWeapon.Object;

            var expectedInfo = $"Hero Hp: {fakeHero.Hp}, Name: {fakeHero.Name}, Class: { fakeHero.GetType().Name}\n" +
                   $"{fakeHero.Additionalinfo()}\n" +
                   $"Hero Weapon:{fakeHero.Weapon.ToString()}\nHero Secret Weapon:{fakeHero.WeaponSecond.ToString()}";

            // Act & Assert
            Assert.AreEqual(expectedInfo, fakeHero.ToString());
        }
    }
}
