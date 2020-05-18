using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFGame
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string levelNumber = cBox.Text;
            string number = levelNumber.Substring(6);
            switch (number)
            {
                case "1":
                    Level1 lvl1 = new Level1();
                    lvl1.Show();
                    break;
                case "2":
                    Level2 lvl2 = new Level2();
                    lvl2.Show();
                    break;
                case "3":
                    Level3 lvl3 = new Level3();
                    lvl3.Show();
                    break;
                case "4":
                    Level4 lvl4 = new Level4();
                    lvl4.Show();
                    break;
                case "5":
                    Level5 lvl5 = new Level5();
                    lvl5.Show();
                    break;
                case "6":
                    Level6 lvl6 = new Level6();
                    lvl6.Show();
                    break;
                case "7":
                    Level7 lvl7 = new Level7();
                    lvl7.Show();
                    break;
            }
            Menu.Close();
        }
    }
}
