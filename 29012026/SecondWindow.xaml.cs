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

namespace _29012029
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
        }

        private void ElementSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = ElementSelector.SelectedIndex + 1;

            Group1.Visibility = (selected >= 1) ? Visibility.Visible : Visibility.Collapsed;
            Group2.Visibility = (selected >= 2) ? Visibility.Visible : Visibility.Collapsed;
            Group3.Visibility = (selected >= 3) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void CalcInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string symbols = "0123456789+-*/";

            if (!symbols.Contains(e.Text))
            {
                e.Handled = true;
                return;
            }

            string currentText = CalcInput.Text; //переменная куда вводится текст из калькулятора
            string opers = "+-*/";

            if (opers.Contains(e.Text))
            {
                if (currentText.Length == 0 || currentText.Any(c => opers.Contains(c))) //блок операнда
                {
                    e.Handled = true;
                }
            }
        }

        private void CalcInput_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CalculateResult();
            }
        }

        private void CalcInput_LostFocus(object sender, RoutedEventArgs e)
        {
            CalculateResult();
        }

        private void CalculateResult()
        {
            if (!CalcInput.IsEnabled || string.IsNullOrEmpty(CalcInput.Text)) return; //пустое или заблокировано - ничего

            string text = CalcInput.Text;
            char[] opers = { '+', '-', '*', '/' };

            int opIndex = text.IndexOfAny(opers);

            if (opIndex > 0 && opIndex < text.Length - 1)
            {
                try
                {
                    long n1 = long.Parse(text.Substring(0, opIndex));
                    long n2 = long.Parse(text.Substring(opIndex + 1));
                    char op = text[opIndex];
                    double res = 0;

                    if (op == '+') res = n1 + n2;
                    if (op == '-') res = n1 - n2;
                    if (op == '*') res = n1 * n2;
                    if (op == '/')
                    {
                        if (n2 == 0) { MessageBox.Show("На ноль делить нельзя"); return; }
                        res = (double)n1 / n2;
                    }

                    CalcInput.Text = $"{text} = {res}";
                    CalcInput.IsEnabled = false; 
                }
                catch { MessageBox.Show("Ошибка в числах"); }
            }
        }

        private void TextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            string t = TextInput.Text;

            if (t.EndsWith("."))
            {
                int engLetters = 0;
                long sum = 0;
                string currentNumber = ""; 

                foreach (char c in t)
                {
                    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                    {
                        engLetters++;
                    }

                    if (char.IsDigit(c))
                    {
                        currentNumber += c; 
                    }
                    else
                    {
                        if (currentNumber != "")
                        {
                            sum += long.Parse(currentNumber);
                            currentNumber = ""; 
                        }
                    }
                }

                MessageBox.Show(
                    "Длина текста: " + t.Length + "\n" +
                    "Английских букв: " + engLetters + "\n" +
                    "Сумма всех чисел: " + sum
                );
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            new ThirdWindow().ShowDialog();
        }
    }
}

