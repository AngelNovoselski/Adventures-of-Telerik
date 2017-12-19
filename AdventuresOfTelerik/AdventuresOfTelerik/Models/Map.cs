using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOfTelerik.Models
{
    public class Map
    {
        private int row;
        private int col;
        private char[,] firstMap;
        public Map(int row, int col)
        {
            this.Row = row;
            this.Col = col;
           
            firstMap = new char [,]{ { '-', '-', '-' } ,{ '-', '-', '-' } ,{ '-', '@','@' } };
        }

        public int Row { get => row; set => row = value; }
        public int Col { get => col; set => col = value; }
    }
}
