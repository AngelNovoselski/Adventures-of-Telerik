using System;
using System.Text;

namespace AdventuresOfTelerik.Models
{
    public struct HeroCoordinates
    {
        public HeroCoordinates(Hero.Hero hero)
        {
            this.X = hero.PositionX;
            this.Y = hero.PositionY;
        }

        public double X { get; private set; }
        public double Y { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Hero Position: ").Append(this.X).Append(", ").Append(this.Y);
            return sb.ToString();
        }
    }
}
