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
    /// <summary>
    /// Логика взаимодействия для Level5.xaml
    /// </summary>
    public partial class Level5 : Window
    {
        CheckBox trueItem = new CheckBox
        {
            Name = "tItem",
            Content = "Ты нашел меня",
        };

        public Level5()
        {
            InitializeComponent();
            Grid.PreviewMouseMove += OnMouseMove;
            Grid.PreviewMouseLeftButtonUp += OnMouseUp;
            Grid.PreviewMouseLeftButtonDown += OnMouseDown;
            Random rnd = new Random();
            int first = rnd.Next(5, 10);
            bool flag = false;
            for (int i = 0; i < first; i++)
            {
                int second = rnd.Next(5, 10);
                MenuItem mi2 = new MenuItem();
                mi2.Header = "Найди меня";
                for (int j = 0; j < second; j++)
                {
                    int third = rnd.Next(6, 10);
                    MenuItem mi1 = new MenuItem();
                    mi1.Header = "Залезь поглубже";
                    for (int k = 0; k < third; k++)
                    {
                        int pos = rnd.Next(0, third);
                        MenuItem mi = new MenuItem();
                        mi.Header = "это не я";
                        mi1.Items.Add(mi);
                        if (!flag && pos == k)
                        {
                            mi1.Items.Add(trueItem);
                            flag = true;
                        }
                    }
                    mi2.Items.Add(mi1);
                }
                cm.Items.Add(mi2);
            }
        }

        private object _captured;
        private Point _capturePosition;

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            _captured = null;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            _captured = e.Source as Button;
            _capturePosition = e.GetPosition(Button);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_captured != null)
            {
                var pos = e.GetPosition(Grid);
                // тащим за то что взяли      
                pos.Offset(-_capturePosition.X, -_capturePosition.Y);
                Button.Margin = new Thickness(pos.X, pos.Y, 0, 0);
            }
        }

        private void NextLevel()
        {
            Level6 lvl6 = new Level6();
            lvl6.Show();
            Lvl5.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)trueItem.IsChecked && (bool)cBox.IsChecked)
            {
                button.Content = "Go";
                NextLevel();
            }
        }
    }
}
