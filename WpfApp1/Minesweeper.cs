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

        public void initGame(Size size)
        {
            int x = (int)Math.Floor(size.Width);
            int y = (int)Math.Floor(size.Height);
            cells = new int[x, y];
        }

        public string 


        /*
         * Create a Event Dispatcher. Alert when a cell changes
         * 
         * /


    }
}
