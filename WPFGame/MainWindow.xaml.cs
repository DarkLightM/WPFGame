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
        private int i = 20;
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            label.Content = "Timer " + i;
            CommandManager.InvalidateRequerySuggested();
            i--;
            mButton.MouseEnter += Button_MouseEnter;
            if (i == -1)
                EndGame();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (stopBox.IsChecked == false)
            {
                Random rnd = new Random();
                int width = rnd.Next(50, 250);
                int height = rnd.Next(50, 250);
                mButton.Margin = new Thickness(width, height, 0, 0);
            }
        }

        private void BotLeftButton_Click(object sender, RoutedEventArgs e)
        {
            gMain.Children.Remove(TopRightButton);
            if (!(gMain.Children.Contains(TopRightButton) || gMain.Children.Contains(BotRightButton)))
                gMain.Children.Remove(BotLeftButton);
        }

        private void MButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (stopBox.IsChecked == true)
            {
                gMain.Children.RemoveRange(1, 6);
                dispatcherTimer.Stop();
                label.Content = "You won";
                Button button = new Button()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Content = "Next Level",
                };
                gMain.Children.Add(button);
            }
        }

        private void BotRightButton_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            gMain.Children.Remove(BotRightButton);
        }

        private void EndGame()
        {
            gMain.Children.RemoveRange(0, 6);
            dispatcherTimer.Stop();
            MessageBox.Show("You lost!!!");
        }
    }
}
