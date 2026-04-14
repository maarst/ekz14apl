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

namespace _22._01._2026
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Pic1.Source = new BitmapImage(new Uri("img1.png", UriKind.Relative));
                Pic2.Source = new BitmapImage(new Uri("img2.png", UriKind.Relative));
            }
            catch { }
        }

        private void T2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Length > 0)
                tb.BorderThickness = new Thickness(0, 0, 0, 1);
            else
                tb.BorderThickness = new Thickness(0, 0, 0, 0);
        }

        private void T3_Main_LostFocus(object sender, RoutedEventArgs e)
        {
            T3_Main.TextDecorations = TextDecorations.Underline;
        }

        private void T3_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                T3_Main.TextDecorations = TextDecorations.Underline;
            }
        }

        private void EngInput_TextChanged(object sender, TextChangedEventArgs e)
{
    string eng = "QWERTYUIOP[]ASDFGHJKL;'ZXCVBNM,.qwertyuiop[]asdfghjkl;'zxcvbnm,.";
    string rus = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбю";

    string input = EngInput.Text;
    string result = "";

    for (int i = 0; i < input.Length; i++)
    {
        char c = input[i];
        int index = eng.IndexOf(c);

        if (index >= 0)
            result += rus[index];
        else
            result += c;
    }

    RusOutput.Text = result;
}

        private void Pic1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                var temp = Pic1.Source;
                Pic1.Source = Pic2.Source;
                Pic2.Source = temp;
            }
        }

        private void Combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Combo1.SelectedIndex == 1)
            {
                Combo2.SelectedIndex = 1; 
                Combo3.SelectedIndex = 1; 
            }
        }
    }
}

