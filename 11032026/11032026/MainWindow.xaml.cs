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

namespace _11032026
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] words = { "береза", "машина", "ноутбук", "дом", "клен" };
        string[] logins = { "login1", "login2", "login3" };
        string[] passwords = { "pass1", "pass2", "pass3" };
        public MainWindow()
        {
            InitializeComponent();

            //определение переменных
            //string d = "alkdjlkas";
            //float c = 9.0f;
            //int r = 0;
            //char i = 'A';
            //bool o = false;

            ////массивы
            //int[] a = { 1, 2, 3 }; //одномерный
            //int[,] b = {{1,2,3}, {4,5,6}}; //двумепный
            //List<int> u = new List<int>(); //динамический

            ////два числа сложить
            //int l1 = 5;
            //int l2 = 6;
            //Console.WriteLine(l1+l2);

            ////дробных числа
            //float fl1 = 9.32f;
            //float fl2 = 8.23f;
            //Console.WriteLine(fl1+fl2);

            ////два символьных
            //char ch1 = 'A';
            //char cr2 = 'B';
            //Console.WriteLine(ch1+cr2);

            ////две строки
            //string st1 = "flilfdsfds";
            //string st2 = "bpopohf";
            //Console.WriteLine(st1+st2);
        }

        //private void Button_ClickText(object sender, RoutedEventArgs e)
        //{
        //    string text = ImputText.Text;
        //    MessageBox.Show(text);
        //}

        //private void Button_ClickMassive(object sender, RoutedEventArgs e)
        //{
        //    string input = ImputText.Text.Trim();
        //    bool found = false;
        //    int index = -1;

        //    for (int i = 0; i < words.Length; i++)
        //    {
        //        if (words[i] == input)
        //        {
        //            found = true;
        //            index = i;
        //            break;
        //        }
        //    }

        //    if (found)
        //    {
        //        MessageBox.Show($"{index}");
        //    }
        //    else
        //    {
        //        MessageBox.Show($"не найдено");
        //    }
        //}


        //опеределить два массива. один отвечает за логин, второй за пароль
        //проверка есть ли логин и индекс

        private void Button_ClickSign(object sender, RoutedEventArgs e)
        {
            string login = LoginText.Text.Trim();
            string password = PasswordText.Text.Trim();

            int loginIndex = Array.IndexOf(logins, login);
            int passwordIndex = Array.IndexOf(passwords, password);

            if (loginIndex == -1)
                MessageBox.Show("логин не найден");
            else if (passwordIndex == -1)
                MessageBox.Show("пароль не найден");
            else if (loginIndex == passwordIndex)
                MessageBox.Show("пароль и логин верны");
            else
                MessageBox.Show("логин и пароль не соответствуют друг другу");
        }
    }
}
