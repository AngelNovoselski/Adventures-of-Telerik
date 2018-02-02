using AdventuresOfTelerik.Contracts;
using AdventuresOfTelerik.Models.MessagesForPrinting;
using System;

namespace AdventuresOfTelerik.Models
{
    public class Map : IMap
    {
        private int row = 10;
        private int col = 10;
        private char[,] firstMap;

        public Map()
        {
            if (this.Row < 1)
            {
                throw new ArgumentOutOfRangeException(GlobalMessages.RowRangeException);
            }
            this.Row = row;

            if (this.Col < 1)
            {
                throw new ArgumentOutOfRangeException(GlobalMessages.ColRangeException);
            }
            this.Col = col;

            FirstMap = new char[this.Row, this.Col];
            FirstMap = new char[,]
            {
                { '@' , '@' , '@' , '@' , '@' , '@' , '@' , '@' , '@' , '@' },
                { '@' , '-' , '1' , '-' , '-' , '-' , '@' , '-' , '@' , '@' },
                { '@' , '-' , '-' , '1' , '-' , '-' , '-' , '-' , '-' , '@' },
                { '@' , '1' , '-' , '-' , '@' , '1' , '@' , '-' , '1' , '@' },
                { '@' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '-' , '@' },
                { '@' , '@' , '@' , '1' , '-' , '-' , '-' , '-' , '1' , '@' },
                { '@' , '1' , '-' , '-' , '@' , '1' , '@' , '1' , '-' , '@' },
                { '@' , '-' , '1' , '-' , '-' , '-' , '@' , '-' , '-' , '@' },
                { '@' , '-' , '-' , '-' , '@' , '1' , '@' , '-' , '2' , '@' },
                { '@' , '@' , '@' , '@' , '@' , '@' , '@' , '@' , 'x' , '@' },
            };
        }

        public int Row { get => this.row; private set => this.row = value; }
        public int Col { get => this.col; private set => this.col = value; }
        public char[,] FirstMap { get => this.firstMap; private set => this.firstMap = value; }
    }
}
