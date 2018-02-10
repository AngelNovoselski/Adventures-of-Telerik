using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventuresOfTelerik.Models;

namespace AdventuresOfTelerik.Tests.Models.FightModeTests
{
    [TestClass]
    public class FightModeTests_Should
    {
        [TestMethod]
        public void PlaySound_OnFightedMonster()
        {
            //untestable
            var mode = new FightMode();
            var mode1 = new Mock<IFightMode>();
            object x = 6;
            EventArgs y = EventArgs.Empty;
            mode1.Object.OnFightedMonster(x, y);

            mode1.Verify(z => z.OnFightedMonster(x,y), Times.Exactly(1));
        }
    }
}
