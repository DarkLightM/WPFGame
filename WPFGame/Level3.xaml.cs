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
using System.Windows.Shapes;

namespace WPFGame
{
    public partial class Level3 : Window
    {
        int[,] Field = new int[3, 3];
        bool flag = false;
        public Level3()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            rb.IsChecked = true;
            rb.Content = "X";
            rb.FontSize = 20;
            rb.GroupName = "Used";
            FillField(rb, 1);
            if (!flag)
                EnemyTurn();
        }

        private void FillField(object sender, int player)
        {
            RadioButton rb = (RadioButton)sender;
            string name = rb.Name.ToString();
            short row = Convert.ToInt16(name[1].ToString());
            short column = Convert.ToInt16(name[2].ToString());
            Field[row, column] = player;
            CheckField();
        }

        private void EnemyTurn()
        {
            List<RadioButton> freeSpace = new List<RadioButton>();
            foreach (object obj in gMain.Children)
            {
                if (obj is RadioButton rb)
                {
                    if (!rb.GroupName.Equals("Used"))
                        freeSpace.Add(rb);
                }
            }
            Random rnd = new Random();
            int point = rnd.Next(freeSpace.Count);
            freeSpace[point].IsChecked = true;
            freeSpace[point].Content = "O";
            freeSpace[point].FontSize = 20;
            freeSpace[point].GroupName = "Used";
            FillField(freeSpace[point], 4);
        }

        private void CheckField()
        {
            int[] win = new int[8];
            win[0] = Field[0, 0] + Field[0, 1] + Field[0, 2];
            win[1] = Field[1, 0] + Field[1, 1] + Field[1, 2];
            win[2] = Field[2, 0] + Field[2, 1] + Field[2, 2];

            win[3] = Field[0, 0] + Field[1, 0] + Field[2, 0];
            win[4] = Field[0, 1] + Field[1, 1] + Field[2, 1];
            win[5] = Field[0, 2] + Field[1, 2] + Field[2, 2];

            win[6] = Field[0, 0] + Field[1, 1] + Field[2, 2];
            win[7] = Field[2, 0] + Field[1, 1] + Field[0, 2];
            foreach (int number in win)
            {
                if (number == 3)
                {
                    NextLevel();
                    Lvl3.Close();
                    break;
                }
                if (number == 12)
                {
                    MessageBox.Show("You lost");
                    Lvl3.Close();
                    MainWindow menu = new MainWindow();
                    menu.Show();
                }
            }
        }

        private void NextLevel()
        {
            flag = true;
            Level4 lvl4 = new Level4();
            lvl4.Show();
        }
    }
}
