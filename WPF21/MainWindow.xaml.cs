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
using System.IO;

namespace WPF21
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentResult = "";

        public MainWindow()
        {
            InitializeComponent();
        }
        private double[] GetArray(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new double[0];

            return text.Split(',')
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(double.Parse)
                .ToArray();
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string op = ((Button)sender).Content.ToString();

                double[] a = GetArray(txtArrayA.Text);
                double[] b = GetArray(txtArrayB.Text);

                if (a.Length != b.Length)
                {
                    MessageBox.Show("Массивы разной длины!");
                    return;
                }

                double[] result = new double[a.Length];

                for (int i = 0; i < a.Length; i++)
                {
                    if (op == "+") result[i] = a[i] + b[i];
                    else if (op == "-") result[i] = a[i] - b[i];
                    else if (op == "*") result[i] = a[i] * b[i];
                    else if (op == "/")
                    {
                        if (b[i] == 0) throw new DivideByZeroException();
                        result[i] = a[i] / b[i];
                    }
                }

                ShowCalculation(a, b, result, op);
                btnSave.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void ShowCalculation(double[] a, double[] b, double[] result, string op)
        {
            var text = new StringBuilder();
            text.AppendLine("Вычисление:");

            for (int i = 0; i < a.Length; i++)
            {
                text.AppendLine($"{a[i]} {op} {b[i]} = {result[i]}");
            }

            text.AppendLine();
            text.Append($"Результат: [{string.Join(", ", result)}]");

            currentResult = text.ToString();
            txtResult.Text = currentResult;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentResult))
            {
                MessageBox.Show("Нет данных для сохранения");
                return;
            }

            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Filter = "Текстовые файлы|*.txt";
            dialog.FileName = $"результат.txt";

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, currentResult);
                MessageBox.Show("Файл успешно сохранен!");
            }
        }
    }
}
