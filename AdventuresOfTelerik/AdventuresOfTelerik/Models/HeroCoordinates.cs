using System.Text;
using AdventuresOfTelerik.Contracts.HeroInterfaces;
using System;

namespace AdventuresOfTelerik.Models
{
    public struct HeroCoordinates : IHeroCoordinates
    {
        private readonly IHero hero;

        public HeroCoordinates(IHero hero)
        {
            this.hero = hero ?? throw new ArgumentNullException();
        }

        public double X { get { return this.Hero.PositionX; } }
        public double Y { get { return this.Hero.PositionY; } }

        public IHero Hero => hero;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Hero Position: ").Append(this.X).Append(", ").Append(this.Y);
            return sb.ToString();
        }
    }
}
