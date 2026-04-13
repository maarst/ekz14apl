using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace _190126
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
            this.Closed += (s, e) => Application.Current.Shutdown();
        }

        private void ManualDateBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[0-9]+$");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            string fileName = $"блокнот_{rnd.Next(1, 10000)}.txt";
            File.WriteAllText(fileName, NoteTextBox.Text);
        }
    }
}
