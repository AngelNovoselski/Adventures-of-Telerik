using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using AdventuresOfTelerik.Models;

namespace AdventuresOfTelerik.Tests.Models.HeroCoordinatesTests
{
    [TestClass]
    public class HeroCoordinates_Should
    {
        [TestMethod]
        public void SetCorrectHero()
        {
            //arrange
            var stubHero = new Mock<IHero>();

            //act
            var heroCoords = new HeroCoordinates(stubHero.Object);

            //assert
            Assert.AreEqual(stubHero.Object, heroCoords.Hero);
        }
        [TestMethod]
        public void Throw_When_HeroIsNull()
        {
            //arrange
            //act
            //assert
            Assert.ThrowsException<ArgumentNullException>(() => new HeroCoordinates(null));
        }

        [TestMethod]
        public void ReturnCorrect_ToString()
        {
            //arrange
            var mockHero = new Mock<IHero>();
           // mockHero.Setup(x => x.PositionX);
            //mockHero.Setup(x => x.PositionY);

            //act
            var heroCoords = new HeroCoordinates(mockHero.Object);

            //assert
            heroCoords.ToString();
            mockHero.Verify(x => x.PositionX, Times.Once);
            mockHero.Verify(x => x.PositionY, Times.Once);
        }

    }
}
