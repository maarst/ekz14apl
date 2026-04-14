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

namespace _141125
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
{
    int num1, num2;

    if (!int.TryParse(textBox1.Text, out num1) ||
        !int.TryParse(textBox2.Text, out num2))
    {
        MessageBox.Show("Введите корректные числа!");
        return;
    }

    if (num1 > num2)
        label1.Text = "Число 1 больше числа 2";
    else if (num1 < num2)
        label1.Text = "Число 1 меньше числа 2";
    else
        label1.Text = "Числа равны";
}

        private void One(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
        }

        private void Two(object sender, TextCompositionEventArgs e)
        {
            char inputChar = e.Text[0];

            if (!char.IsDigit(inputChar) && inputChar != ';')
            {
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(TextBoxSize.Text, out int size) || size < 1 || size > 20)
            {
                MessageBox.Show("Размер массива должен быть от 1 до 20.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            List<int> finalArray = new List<int>();
            long sum = 0;

            string[] inputParts = TextBoxElements.Text.Split(';');

            foreach (string part in inputParts)
            {
                if (finalArray.Count >= size)
                {
                    break;
                }

                if (int.TryParse(part.Trim(), out int number))
                {
                    finalArray.Add(number);

                    sum += number;
                }
            }

            string arrayString = (finalArray.Count > 0)? string.Join(" ", finalArray): "Нет элементов";

            string message = $"Размер:{size}\n"+$"Элементы ({finalArray.Count}): {arrayString}\n"+$"Сумма: {sum}";

            MessageBox.Show(message, "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
