using AdventuresOfTelerik.Common.Enums;
using AdventuresOfTelerik.Contracts.WeaponInterfaces;
using AdventuresOfTelerik.Tests.Models.Heroes.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AdventuresOfTelerik.Tests.Models.Heroes.Heroes
{
    [TestClass]
    public class Hero_Should
    {
        [TestMethod]
        public void SetCorrectData_When_Valid()
        {
            //arrange
            var color = HeroColor.red;
            var knife = new Mock<IKnife>();

            //act
            var fakeHero = new FakeAbstractHero(color, knife.Object);

            //assert
            Assert.AreEqual("Telerik", fakeHero.Name);
            Assert.AreEqual(1, fakeHero.PositionX);
            Assert.AreEqual(1, fakeHero.PositionY);
            Assert.AreEqual(450, fakeHero.Hp);
            Assert.AreEqual(1, fakeHero.Level);
            Assert.AreEqual(0, fakeHero.Exp);
            Assert.AreEqual(color, fakeHero.HeroColor);
            Assert.AreEqual(knife.Object, fakeHero.WeaponSecond);
        }

        [TestMethod]
        public void SetCorrectWeapon_When_WeaponIsValid()
        {
            //arrange
            var weapon = new Mock<IWeapon>();

            var color = HeroColor.red;
            var knife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, knife.Object);

            //act 
            fakeHero.Weapon = weapon.Object;

            //assert
            Assert.AreEqual(weapon.Object, fakeHero.Weapon);
        }

        [TestMethod]
        public void ThrowArgumentException_When_WeaponIsNull()
        {
            //arrange
            var color = HeroColor.red;
            var knife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, knife.Object);

            //act & assert
            Assert.ThrowsException<ArgumentNullException>(() => fakeHero.Weapon = null);
        }

        [TestMethod]
        public void SetCorrectSecondWeapon_When_SecondWeaponIsValid()
        {
            //arrange
            var weapon = new Mock<IWeapon>();

            var color = HeroColor.red;
            var knife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, knife.Object);

            //act 
            fakeHero.WeaponSecond = weapon.Object;

            //assert
            Assert.AreEqual(weapon.Object, fakeHero.WeaponSecond);
        }

        [TestMethod]
        public void ThrowArgumentException_When_SecondWeaponIsNull()
        {
            //arrange
            var color = HeroColor.red;
            var knife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, knife.Object);

            //act & assert
            Assert.ThrowsException<ArgumentNullException>(() => fakeHero.WeaponSecond = null);
        }

        [TestMethod]
        public void SetCorrectNewValues_When_MovingLeft()
        {
            //arrange
            var left = 1;
            var color = HeroColor.red;
            var knife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, knife.Object);

            var currentPosition = fakeHero.PositionY;

            //act
            fakeHero.Move(left);

            //assert
            Assert.AreEqual(currentPosition - 1, fakeHero.PositionY);
        }

        [TestMethod]
        public void SetCorrectNewValues_When_MovingRight()
        {
            //arrange
            var right = 2;
            var color = HeroColor.red;
            var knife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, knife.Object);

            var currentPosition = fakeHero.PositionY;

            //act
            fakeHero.Move(right);

            //assert
            Assert.AreEqual(currentPosition + 1, fakeHero.PositionY);
        }

        [TestMethod]
        public void SetCorrectNewValues_When_MovingUp()
        {
            //arrange
            var up = 3;
            var color = HeroColor.red;
            var knife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, knife.Object);

            var currentPosition = fakeHero.PositionX;

            //act
            fakeHero.Move(up);

            //assert
            Assert.AreEqual(currentPosition - 1, fakeHero.PositionX);
        }

        [TestMethod]
        public void SetCorrectNewValues_When_MovingDown()
        {
            //arrange
            var down = 4;
            var color = HeroColor.red;
            var knife = new Mock<IKnife>();
            var fakeHero = new FakeAbstractHero(color, knife.Object);

            var currentPosition = fakeHero.PositionX;

            //act
            fakeHero.Move(down);

            //assert
            Assert.AreEqual(currentPosition + 1, fakeHero.PositionX);
        }

        [TestMethod]
        public void ToStringReturnCorrectInfo()
        {
            //arrange

            var color = HeroColor.red;
            var knife = new Mock<IKnife>();
            var weapon = new Mock<IWeapon>();
            var fakeHero = new FakeAbstractHero(color, knife.Object);
            fakeHero.Weapon = weapon.Object;
           
            var expectedInfo = $"Hero Hp: {fakeHero.Hp}, Name: {fakeHero.Name}, Class: { fakeHero.GetType().Name}\n" +
                   $"{fakeHero.Additionalinfo()}\n" +
                   $"Hero Weapon:{fakeHero.Weapon.ToString()}\nHero Secret Weapon:{fakeHero.WeaponSecond.ToString()}";

            //act & assert
            Assert.AreEqual(expectedInfo, fakeHero.ToString());
        }
    }
}
