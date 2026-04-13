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
using System.IO;

namespace _29012029
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

        private void LoginBox_CheckText(object sender, TextCompositionEventArgs e)
        {
            char c = e.Text[0];

            if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
            {
                e.Handled = true; 
            }
        }

        private void LoginBox_CheckSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PassBox.Password;

            if (login == "" || password == "")
            {
                MessageBox.Show("Поля не должны быть пустыми!");
                return;
            }

            if (CheckAuth(login, password))
            {
                SecondWindow windowsTwo = new SecondWindow();
                windowsTwo.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private bool CheckAuth(string login, string pass)
        {
            string path = "users.txt";

            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length - 1; i++)
            {
                string fileLogin = lines[i].Trim();
                string filePass = lines[i + 1].Trim();

                if (fileLogin == login && filePass == pass)
                {
                    return true;
                }

                i++;
            }

            return false;
        }
    }
}

