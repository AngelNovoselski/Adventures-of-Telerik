using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventuresOfTelerik.Tests.Models.CollisionDetectorTests
{
    [TestClass]
    public class CheckCollisions_Should
    {
        [TestMethod]
        public void ReturnProperChar()
        {
            // Arrange
            var detector = new CollisionDetector();
            var map = new Mock<IMap>();

            int positionX = 5;
            int positionY = 5;
            char[,] zzz = new char[10, 10];
            zzz[5,5] = '-';

            map.SetupGet(x => x.FirstMap).Returns(zzz);

            // Act
            var expected = detector.CheckCollisions(positionX, positionY, map.Object);
            char actualresult = '-';

            // Assert
            Assert.AreEqual(expected, actualresult);
        }
    }
}
