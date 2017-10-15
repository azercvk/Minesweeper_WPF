using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Minesweeper
{
    class Cell : Button
    {
        private string type = "";
        public int x { get; } = 0;
        public int y { get; } = 0;


        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.Content = " ";
            Grid.SetColumn(this, x);
            Grid.SetRow(this, y);

            

            this.Click += clicked;
        }

        public void setMine()
        {
            this.type = "mine";
        }

        private void clicked(object sender, EventArgs e)
        {

            // Call to the minesweeper class to keep track of the logic


            
        }
    }
}
