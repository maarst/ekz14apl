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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для StringsWindow.xaml
    /// </summary>
    public partial class StringsWindow : Window
    {
        public StringsWindow()
        {
            InitializeComponent();
        }

        private void Do_Click(object sender, RoutedEventArgs e)
        {
            var inputs = new[] { Text1.Text, Text2.Text, Text3.Text };

            if (inputs.Any(string.IsNullOrWhiteSpace))
            {
                MessageBox.Show("Все три поля должны быть заполнены!");
                return;
            }

            string result = string.Concat(inputs);
            result = Regex.Replace(result, @"[\s!@#№$%^&*()_+=\[\]{};:'"",.<>?/\\|`~]", "");
            ResultText.Text = result;
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

    }
}
