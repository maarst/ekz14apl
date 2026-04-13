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

namespace Blocnot.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            string loginInput = TxtLogin.Text.Trim();
            string passwordInput = TxtPassword.Password.Trim();

            if (string.IsNullOrEmpty(loginInput) || string.IsNullOrEmpty(passwordInput))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            var lines = File.ReadAllLines(MainWindow.NotesPath);
            bool success = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (line.StartsWith("логин") && line.Contains(":"))
                {
                    var loginParts = line.Split(new char[] { ':' }, 2);
                    string fileLogin = loginParts[1].Trim();

                    if (fileLogin == loginInput)
                    {
                        if (i + 1 < lines.Length)
                        {
                            string passwordLine = lines[i + 1].Trim();
                            if (passwordLine.StartsWith("пароль") && passwordLine.Contains(":"))
                            {
                                var passParts = passwordLine.Split(new char[] { ':' }, 2);
                                string filePassword = passParts[1].Trim();

                                if (filePassword == passwordInput)
                                {
                                    success = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (success)
                MessageBox.Show("Вход успешно выполнен!");
            else
                MessageBox.Show("Вход не выполнен!");
        }

    }
}
