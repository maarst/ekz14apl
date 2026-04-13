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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _190126
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isFirst = true;

        public MainWindow()
        {
            InitializeComponent();
            new SecondWindow().Show();
        }

        private void ShowMessage_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("привет");
        }

        private void EnglishTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        { 
            e.Handled = !Regex.IsMatch(e.Text, @"^[a-zA-Z ]+$");
        }

        private void ToggleImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isFirst = !isFirst;
            ToggleImage.Source = new BitmapImage(new Uri(isFirst ? "image1.png" : "image2.png", UriKind.Relative));
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            ((CheckBox)sender).IsEnabled = false;
        }

    }
}
