using System;
using System.Collections.Generic;
using System.IO;
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

    public partial class Level2 : Window
    {
        private Dictionary<string, string[]> Questions = new Dictionary<string, string[]>();
        private Dictionary<int, string> Numeric = new Dictionary<int, string>();
        int input = 0;
        int i = 0;

        public Level2()
        {
            InitializeComponent();
            string path = "Pack.txt";
            string line;
            StreamReader reader = new StreamReader(path);
            while ((line = reader.ReadLine()) != null)
            {
                string[] arr = line.Split('_');
                string[] answers = arr[1].Split(' ');
                Questions[arr[0]] = answers;
                Numeric[input] = arr[0];
                input++;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string question = Numeric[i];
            string userAnswer = textBox.Text.ToLower();
            string[] trueAnswers = Questions[question];
            Label userAnswerLabel = new Label
            {
                Content = userAnswer,
            };
            sPanel.Children.Add(userAnswerLabel);
            Label nextTurn = new Label()
            {
                Content = "Увы, ты неправ.",
            };
            if (i == Numeric.Count - 1)
            {
                Button button = new Button()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Content = "Next Level",
                };
                sPanel.Children.Add(button);
                button.Click += BeginNextLvl;
            }
            foreach (string trueAnswer in trueAnswers)
            {
                if ((i < Numeric.Count - 1) && userAnswer.Equals(trueAnswer))
                {
                    nextTurn.Content = Numeric[i + 1];
                    i++;
                    break;
                }
                if (i == Numeric.Count - 1)
                    nextTurn.Content = "Ты справился, мои поздравления";
            }
            sPanel.Children.Add(nextTurn);
            
            textBox.Text = "";
        }
        private void BeginNextLvl(object sender, RoutedEventArgs e)
        {
            Level3 lvl3 = new Level3();
            lvl3.Show();
            Lvl2.Close();
        }
    }
}
