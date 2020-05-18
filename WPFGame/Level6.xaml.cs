using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Media;
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
    public partial class Level6 : Window
    {
        public string[,] TrueAnswers = new string[,] { { "токийский гуль", "кланнад", "берсерк", "да конечно уже залезаю давай" },
            { "варкрафт 3 варик warcraft", "доки доки doki doki", "ведьмак 3 witcher 3", "1997 1998 1999" },
            { "бригада", "форсаж", "тайлер дерден дёрден", "выживший" },
            {"2 второй" ,"а что звучит хайпово" ,"12 конфет" ,"да"} };
        public TreeViewItem SelectedItem = new TreeViewItem();
        public int Counter = 0;
        public bool HasImg;

        public Level6()
        {
            InitializeComponent();
        }

        private void T_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvItem = (TreeViewItem)sender;
            string name = tvItem.Name;
            char mode = name[2];
            switch (mode)
            {
                case '0':
                    string aPath = "Level6/" + name + ".wav";
                    SoundPlayer sp = new SoundPlayer
                    {
                        SoundLocation = aPath,
                    };
                    tblock.Text = "Откуда данный саунд?";
                    if (name.Length == 4)
                        tblock.Text = "Назоите номер инта.";
                    sp.Load();
                    sp.Play();
                    break;
                case '1':
                    string pPath = "D:/Git/WPFGame/WPFGame/bin/Debug/Level6/" + name + ".jpg";
                    Image myImage = new Image
                    {
                        Source = new BitmapImage(new Uri(pPath)),
                        HorizontalAlignment = HorizontalAlignment.Right,
                        Name = "image",
                    };
                    gMain.Children.Add(myImage);
                    HasImg = true;
                    tblock.Text = "Откуда пикча?";
                    if (name.Length == 4)
                        tblock.Text = "Какой текст пропущен?";
                    break;
                default:
                    string path = "D:/Git/WPFGame/WPFGame/bin/Debug/Level6/" + name + ".txt";
                    StreamReader reader = new StreamReader(path);
                    tblock.Text = reader.ReadToEnd();
                    break;
            }
            SelectedItem = tvItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string answer = tbox.Text;
            answer.ToLower();
            string name = SelectedItem.Name;
            int theme = Convert.ToInt32(name[1].ToString());
            int question = Convert.ToInt32(name[2].ToString());
            if (TrueAnswers[theme, question].Contains(answer))
            {
                MessageBox.Show("Ты прав");
                Counter++;
                tbCounter.Text = "Правильные ответы " + Counter;
                if (Counter == 10)
                {
                    Button button = new Button
                    {
                        Content = "Next level",
                    };
                    gMain.Children.Add(button);
                    button.Click += ButtonLevel_Click;
                }
            }
            else
                MessageBox.Show("Неправильно");
            if (HasImg)
            {
                Image img = new Image();
                foreach (object obj in gMain.Children)
                    if (obj is Image)
                        img = (Image)obj;
                gMain.Children.Remove(img);
                HasImg = false;
            }
            TreeViewItem parent = (TreeViewItem)SelectedItem.Parent;
            parent.Items.Remove(SelectedItem);
            tbox.Text = "";
        }

        private void ButtonLevel_Click(object sender, RoutedEventArgs e)
        {
            Level7 lvl7 = new Level7();
            lvl7.Show();
            Lvl6.Close();
        }
    }
}
