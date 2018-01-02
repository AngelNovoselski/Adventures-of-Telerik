using AdventuresOfTelerik.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models
{
    public class Map : IMap
    {
        private int row = 13;
        private int col = 10;
        private char[,] firstMap;

        public Map()
        {
            if (this.Row < 1)
            {
                throw new ArgumentOutOfRangeException("Row must be bigger than 1!!!");
            }
            this.Row = row;

            if (this.Col < 1)
            {
                throw new ArgumentOutOfRangeException("Col must be bigger than 1!!!");
            }
            this.Col = col;

            FirstMap = new char[this.Row, this.Col];
            FirstMap = new char[,]
            {
                { '@' , '@' , '@' , '@' , '@' , '@' , '@' , '@' , '@' , '@' },
                { '@' , '@' , '@' , '@' , 'x' , '@' , '@' , '@' , '@' , '@' },
                { '@' , '@' , '@' , '@' , '4' , '@' , '@' , '@' , '@' , '@' },
                { '@' , '@' , '-' , '-' , '-' , '-' , '-' , '@' , '@' , '@' },
                { '@' , '@' , '-' , '@' , '-' , '@' , '-' , '@' , '@' , '@' },
                { '@' , '@' , '-' , '@' , '-' , '@' , '-' , '@' , '@' , '@' },
                { '@' , '@' , '2' , '@' , '2' , '@' , '2' , '@' , '@' , '@' },
                { '@' , '@' , '-' , '@' , '-' , '@' , '-' , '@' , '@' , '@' },
                { '@' , '@' , '-' , '-' , '3' , '-' , '-' , '@' , '@' , '@' },
                { '@' , '@' , '@' , '@' , '1' , '@' , '@' , '@' , '@' , '@' },
                { '@' , '@' , '@' , '@' , '-' , '@' , '@' , '@' , '@' , '@' },
                { '@' , '@' , '@' , '@' , '-' , '@' , '@' , '@' , '@' , '@' },
                { '@' , '@' , '@' , '@' , '@' , '@' , '@' , '@' , '@' , '@' },
            };
        }

        public int Row { get => this.row; private set => this.row = value; }
        public int Col { get => this.col; private set => this.col = value; }
        public char[,] FirstMap { get => this.firstMap; set => this.firstMap = value; }
    }
}
