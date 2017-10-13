﻿using System;
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

        private void addButton(int x, int y)
        {
            Console.WriteLine("Adding button ({0}, {1})", x, y);

            Button btn = new Button();
            btn.Content = " ";
            Grid.SetColumn(btn, x);
            Grid.SetRow(btn, y);
            gameboard.Children.Add(btn);
        }

        private void addRows(int rows)
        {
            for(int i = 0; i < rows; i++)
            {
                gameboard.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void addCols(int cols)
        {
            for (int i = 0; i < cols; i++)
            {
                gameboard.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void drawCells(Size size)
        {
            // Clear the board
            gameboard.RowDefinitions.Clear();
            gameboard.ColumnDefinitions.Clear();

            int rows = (int)Math.Floor(size.Height);
            int cols = (int)Math.Floor(size.Width);

            this.addCols(cols);
            this.addRows(rows);

            for(int x = 0; x < size.Width; x++)
            {
                for(int y = 0; y < size.Height; y++)
                {
                    this.addButton(x, y);
                }
            }
        }

        public void btnEasyModeClicked(object sender, RoutedEventArgs e)
        {
            this.drawCells(new Size(12, 23));   
        }
    }
}
