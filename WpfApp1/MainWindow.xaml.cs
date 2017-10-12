using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void clearGamebaord()
        {
            // Delete all rows
            if(gameboard.RowDefinitions.Count > 0)
            {
                RowDefinition[] rows = gameboard.RowDefinitions.ToArray();
                foreach(RowDefinition row in rows)
                {
                    gameboard.RowDefinitions.Remove(row);
                }
            }

            // Delete all Columns
            if (gameboard.ColumnDefinitions.Count > 0)
            {
                ColumnDefinition[] cols = gameboard.ColumnDefinitions.ToArray();
                foreach(ColumnDefinition col in cols)
                {
                    gameboard.ColumnDefinitions.Remove(col);
                }
            }
        }

        private void addButton(int x, int y)
        {
            Console.WriteLine("Adding button ({0}, {1})", x, y);

            Button btn = new Button();
            btn.Content = " ";
            Grid.SetColumn(btn, x);
            Grid.SetRow(btn, y);
            gameboard.Children.Add(btn);
        }

        private void drawCells(Size size)
        {
            // Clear the board
            this.clearGamebaord();

            // Create the SQUARE rows and columns
            int square = (int) Math.Floor(size.Width < size.Height ? size.Width : size.Height);
            for(int i = 0; i < square; i++)
            {
                gameboard.ColumnDefinitions.Add(new ColumnDefinition());
                gameboard.RowDefinitions.Add(new RowDefinition());

                if(i > 0)
                {
                    for (int d = 0; d < i; d++)
                    {
                        // add cells at the bottom of each column
                        this.addButton(i, d);

                        // add cells at the end of each row
                        this.addButton(d, i);
                    }
                }

                this.addButton(i, i);
            }

            // Draw any additional rows or columns
            if(size.Width > size.Height)
            {
                int len = (int) Math.Floor(size.Width - size.Height);
                for(int i = 0; i < len; i++)
                {
                    gameboard.ColumnDefinitions.Add(new ColumnDefinition());
                    int rows = gameboard.ColumnDefinitions.Count;
                    for(int d = 0; d <= rows; d++)
                    {
                        // add cells at the bottom of each column
                        this.addButton(square + i, d);
                    }
                }
            }
            else if(size.Height > size.Width)
            {
                int len = (int) Math.Floor(size.Height - size.Width);
                for(int i = 0; i < len; i++)
                {
                    gameboard.RowDefinitions.Add(new RowDefinition());
                    int cols = gameboard.ColumnDefinitions.Count;
                    for(int d = 0; d <= cols; d++)
                    {
                        // add cells at the end of each row
                        this.addButton(d, square + i);
                    }
                }
            }
        }

        public void btnEasyModeClicked(object sender, RoutedEventArgs e)
        {
            this.drawCells(new Size(15, 26));   
        }
    }
}
