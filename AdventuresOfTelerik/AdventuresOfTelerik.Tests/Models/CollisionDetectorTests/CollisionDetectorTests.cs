using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Models;
using AdventuresOfTelerik.Models.MessagesForPrinting;

namespace AdventuresOfTelerik.Tests.Models
{
    [TestClass]
    public class CollisionDetector_Should
    {
        [TestMethod]
        public void GuideMessage_Should_ReturnProperChar()
        {
            //arrange
            var detector = new CollisionDetector();

            //act
            var result = detector.GuideMessage('-');
            var result1 = detector.GuideMessage('@');
            var result2 = detector.GuideMessage('1');
            var result3 = detector.GuideMessage('2');
            var result4 = detector.GuideMessage('x');

            var expected = GlobalMessages.PathMessage;
            var expected1 = GlobalMessages.RockMessage;
            var expected2 = GlobalMessages.MonsterMessage;
            var expected3 = GlobalMessages.BossMonsterMessage;
            var expected4 = GlobalMessages.ExitMessage;
            //assert
            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected1, result1);
            Assert.AreEqual(expected2, result2);
            Assert.AreEqual(expected3, result3);
            Assert.AreEqual(expected4, result4);
        }
    }
}
