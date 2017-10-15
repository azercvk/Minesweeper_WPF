using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Minesweeper
{
    class Minesweeper
    {
        private int[,] cells = null;

        private static Minesweeper self = null;

        public static Minesweeper getInstance()
        {
            if(self == null)
            {
                self = new Minesweeper();
            }
            return self;
        }

        private Minesweeper()
        {
        }

        public void initGame(Size size, int bombs)
        {
            int x = (int)Math.Floor(size.Width);
            int y = (int)Math.Floor(size.Height);
            cells = new int[x, y];

            Random rnd = new Random();

            for(int i = 0; i < bombs; i++)
            {
                int col = rnd.Next(0, x - 1);
                int row = rnd.Next(0, y - 1);

                if (!this.placeBomb(row, col))
                {
                    i--;
                }
            }
        }

        private bool placeBomb(int x, int y)
        {
            if(cells[x, y] < 0)
            {
                // There is already a bomb here so a bomb cannot be placed
                return false;
            }

            // place the bomb
            cells[x, y] = -1;

            // increment numbers around the bomb
            for(int ix = -1; ix <= 1; ix++)
            {
                for(int iy = -1; iy <= 1; iy++)
                {
                    if (ix == 0 && iy == 0) continue;

                    this.incrementCounter(x + ix, y + iy);
                }
            }

            return true;
        }

        // If you call this method then a bomb has been added next to this cell
        private void incrementCounter(int x, int y)
        {
            if (x < 0 || y < 0) return;

            int xlen = cells.GetLength(0);
            int ylen = cells.GetLength(1);
            if (x >= xlen || y >= ylen) return;

            // If we are here then the cell we are trying to increment is on the board

            if (cells[x, y] < 0) return; // This cell is a bomb so we cannot increment it

            // Now we are ready to increment the cell
            cells[x, y]++;
        }

        override
        public string ToString()
        {
            string output = "";
            int xlen = cells.GetLength(0);
            int ylen = cells.GetLength(1);

            for(int x = 0; x < xlen; x++)
            {
                for(int y = 0; y < ylen; y++)
                {
                    output += " " + cells[x, y];
                }
                output += "\n";
            }

            return output;
        }

        /*
         * Create a Event Dispatcher. Alert when a cell changes
         * 
         */


    }
}
