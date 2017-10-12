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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static int easyMode = 100;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void clearGamebaord()
        {
            // Delete all rows
            for (int i = 0; i < gameboard.RowDefinitions.Count; i++)
            {
                RowDefinition row = gameboard.RowDefinitions[i];
                gameboard.RowDefinitions.Remove(row);
            };
            // Delete all Columns
            for (int i = 0; i < gameboard.ColumnDefinitions.Count; i++)
            {
                ColumnDefinition col = gameboard.ColumnDefinitions[i];
                gameboard.ColumnDefinitions.Remove(col);
            }
        }

        private void addButton(int x, int y)
        {
            Button btn = new Button();
            btn.Content = " ";
            Grid.SetColumn(btn, x);
            Grid.SetRow(btn, y);
            gameboard.Children.Add(btn);
        }

        private void setCells(int cells)
        {
            Button btn; // place holder for all the buttons
            int len = (int) Math.Floor(Math.Sqrt(cells));

            Console.WriteLine("Len " + len);

            // Clear the board
            this.clearGamebaord();

            // add the same rows and columns as defined by len
            for(int i = 0; i < len; i++)
            {
                gameboard.RowDefinitions.Add(new RowDefinition());
                gameboard.ColumnDefinitions.Add(new ColumnDefinition());

                for(int y = 0; y < i; y++)
                {
                    // Add item (i, y)
                    this.addButton(i, y);

                    // Add item (y, i)
                    this.addButton(y, i);
                }

                // Add item (i, i)
                this.addButton(i, i);

               
                Console.WriteLine("Len %d complete", len);
            }

        }

        public void btnEasyModeCLicked(object sender, RoutedEventArgs e)
        {
            this.setCells(easyMode);   
        }
    }
}
