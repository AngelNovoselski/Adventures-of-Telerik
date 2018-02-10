using AdventuresOfTelerik.Contracts.HeroInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventuresOfTelerik.Tests.Models.Heroes.HeroTests
{
    [TestClass]
    public class OnFightMonster_Should
    {
        [TestMethod]
        public void InvokeFightMonster()
        {
            // Arrange
            //var color = HeroColor.red;
            //var stubKnife = new Mock<IKnife>();
            var fakeHero = new Mock<IHero>();

            // Act
            fakeHero.Object.OnFightMonster();

            // Assert
            fakeHero.Verify(x => x.OnFightMonster(), Times.Exactly(1));
        }
    }
}
