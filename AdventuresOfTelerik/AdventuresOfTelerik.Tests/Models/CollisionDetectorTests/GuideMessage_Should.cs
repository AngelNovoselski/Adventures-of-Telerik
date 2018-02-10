using AdventuresOfTelerik.Models;
using AdventuresOfTelerik.Models.MessagesForPrinting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventuresOfTelerik.Tests.Models.CollisionDetectorTests
{
    [TestClass]
    public class GuideMessage_Should
    {
        [TestMethod]
        public void ReturnProperChar()
        {
            // Arrange
            var detector = new CollisionDetector();

            // Act
            var result = detector.GuideMessage('-');
            var result1 = detector.GuideMessage('@');
            var result2 = detector.GuideMessage('1');
            var result3 = detector.GuideMessage('2');
            var result4 = detector.GuideMessage('x');
            var result5 = detector.GuideMessage('?');

            var expected = GlobalMessages.PathMessage;
            var expected1 = GlobalMessages.RockMessage;
            var expected2 = GlobalMessages.MonsterMessage;
            var expected3 = GlobalMessages.BossMonsterMessage;
            var expected4 = GlobalMessages.ExitMessage;
            var expected5 = string.Empty;

            // Assert
            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected1, result1);
            Assert.AreEqual(expected2, result2);
            Assert.AreEqual(expected3, result3);
            Assert.AreEqual(expected4, result4);
            Assert.AreEqual(expected5, result5);
        }
    }
}
