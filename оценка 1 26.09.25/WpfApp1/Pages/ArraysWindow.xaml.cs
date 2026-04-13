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
using System.Windows.Shapes;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ArraysWindow.xaml
    /// </summary>
    public partial class ArraysWindow : Window
    {
        private int[] array1;
        private int[] array2;

        public ArraysWindow()
        {
            InitializeComponent();
            GenerateArrays();
        }

        private void GenerateArrays()
        {
            Random rnd = new Random();
            array1 = new int[5];
            array2 = new int[5];

            for (int i = 0; i < 5; i++)
            {
                array1[i] = rnd.Next(-10, 11);
                array2[i] = rnd.Next(-10, 11);
            }

            Array1Text.Text = "Массив 1: " + array1[0] + ", " + array1[1] + ", " + array1[2] + ", " + array1[3] + ", " + array1[4];
            Array2Text.Text = "Массив 2: " + array2[0] + ", " + array2[1] + ", " + array2[2] + ", " + array2[3] + ", " + array2[4];
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string result = "";
            for (int i = 0; i < 5; i++)
                result += (array1[i] + array2[i]) + (i < 4 ? ", " : "");
            ResultText.Text = result;
        }

        private void Sub_Click(object sender, RoutedEventArgs e)
        {
            string result = "";
            for (int i = 0; i < 5; i++)
                result += (array1[i] - array2[i]) + (i < 4 ? ", " : "");
            ResultText.Text = result;
        }

        private void Mul_Click(object sender, RoutedEventArgs e) 
        {
            string result = "";
            for (int i = 0; i< 5; i++)
                result += (array1[i]* array2[i]) + (i< 4 ? ", " : "");
            ResultText.Text = result;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
       {
           new MainWindow().Show();   
           this.Close();
       }
    }
}
