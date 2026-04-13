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
    /// Логика взаимодействия для TranslateWindow.xaml
    /// </summary>
    public partial class TranslateWindow : Window
    {
        private readonly Dictionary<char, char> lala;

        public TranslateWindow()
        {
            InitializeComponent();
            string eng = "qwertyuiop[]asdfghjkl;'zxcvbnm,.";
            string rus = "йцукенгшщзхъфывапролджячсмитьбю.";
            lala = new Dictionary<char, char>();
            for (int i = 0; i < eng.Length; i++)
            {
                lala[eng[i]] = rus[i];
            }
        }

        private void Do_Click(object sender, RoutedEventArgs e)
        {
            string input = InputText.Text;
            string output = "";

            foreach (char c in input)
            {
                char lower = char.ToLower(c);

                if (lala.ContainsKey(lower))
                {
                    char translated = lala[lower];

                    if (char.IsUpper(c))
                        translated = char.ToUpper(translated);

                    output += translated;
                }
                else
                {
                    output += c;
                }
            }

            ResultText.Text = output;
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
