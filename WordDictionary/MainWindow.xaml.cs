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

namespace WordDictionary
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WordManager wordManager;
        public MainWindow()
        {
            InitializeComponent();
            wordManager = new WordManager();
            //DropDownBox.ItemsSource = letterManager.GetWords();
        }

        private void InputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadWords();
        }

        private void LoadWords()
        {
            List<string> words = wordManager.GetWordChilds(InputBox.Text.ToLower());
            DropDownBox.ItemsSource = words;
            if (words.Count == 0 && InputBox.Text.Length > 2)
            {
                CreateButton.IsEnabled = true;
            }
            else
            {
                CreateButton.IsEnabled = false;
            }

            test.Text = "Dostępne " + words.Count.ToString() + ":\n";
            foreach (string s in words)
            {
                test.Text += "> " + s + "\n";
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            wordManager.AddWord(InputBox.Text.ToLower());
            CreateButton.IsEnabled = false;
            LoadWords();
        }
    }
}
