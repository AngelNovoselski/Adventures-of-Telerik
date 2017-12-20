using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models
{
    public class Map
    {
        private int row = 5;
        private int col = 5;
        private char[,] firstMap;

        public Map()
        {
            this.Row = row;
            this.Col = col;
            FirstMap = new char[Row, Col];
            FirstMap = new char[,] 
            {
                { '@' , '@' , '@' , '@' , '@' },
                { '@' , '-' , '1' , '-' , '@' },
                { '@' , '-' , '1' , '1' , '@' },
                { '@' , '1' , '-' , '-' , '@' },
                { '@' , '@' , '@' , '@' , '@' },
            };
        }

        public int Row { get; }
        public int Col { get; }
        public char[,] FirstMap { get => firstMap; set => firstMap = value; }
    }
}
