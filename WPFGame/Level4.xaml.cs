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
    public class Country
    {
        public string Continent { get; set; }
        public string CountryName { get; set; }
        public string Capital { get; set; }
        public string HeadOfCountry { get; set; }
    }
    public partial class Level4 : Window
    {
        public List<Country> Countries { get; set; }
        List<string> trueAnswers;
        int counter = 0;

        string[] Bullying = new string[] {"Ты не прав, думай дальше идиот.","Включи мозги, это элементарные вопросы.",
            "Может подумаешь, прежде чем писать?","Ведели бы тебя твои родители...","Неверно!" };

        public Level4()
        {
            InitializeComponent();
            Countries = FillTheList("Countries.txt");
            string path = "TrueAnswers.txt";
            trueAnswers = new List<string>();
            StreamReader reader = new StreamReader(path);
            string line;
            while ((line = reader.ReadLine()) != null)
                trueAnswers.Add(line);
            DataContext = this;
        }
        public List<Country> FillTheList(string path)
        {
            StreamReader reader = new StreamReader(path);
            List<Country> list = new List<Country>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] arr = line.Split('_');
                Country country = new Country
                {
                    Continent = arr[0],
                    CountryName = arr[1],
                    Capital = arr[2],
                    HeadOfCountry = arr[3]
                };
                list.Add(country);
            }
            return list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = tBox.Text;
            bool flag = false;
            text.ToLower();
            foreach (string trueAnswer in trueAnswers)
            {
                if (text.Equals(trueAnswer))
                {
                    counter++;
                    flag = true;
                    break;
                }
            }
            Label label = new Label
            {
                Content = text,
            };
            if (!flag)
            {
                Random rnd = new Random();
                int phrase = rnd.Next(5);
                label.Content = Bullying[phrase];
            }
            sPanel.Children.Add(label);
            tBox.Text = "";
            score.Content = "Правильные ответы: " + counter;
            if (counter == 12)
                NextLevel();
        }
        private void NextLevel()
        {
            Level5 lvl5 = new Level5();
            lvl5.Show();
            Lvl4.Close();
        }
    }
}
