using System;
using System.Collections.Generic;
using System.IO;
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
using Blocnot.Pages;
using IO = System.IO;

namespace Blocnot
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string NotesPath => System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "работа с блокнотом.txt");

        public MainWindow()
        {
            InitializeComponent();
            EnsureNotesFileExists();
        }

        private void EnsureNotesFileExists()
        {
            try
            {
                if (!File.Exists(NotesPath))
                {
                    File.WriteAllText(NotesPath, ""); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось подготовить файл заметок: " + ex.Message);
            }
        }


        private void BtnWrite_Click(object sender, RoutedEventArgs e)
        {
            var win = new EditorWindow(isSingleLine: true)
            {
                Owner = this,
                Mode = EditorWindow.EditorMode.AppendLine
            };
            win.ShowDialog();
        }


        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!File.Exists(NotesPath))
                    File.WriteAllText(NotesPath, "");

                string originalText = File.ReadAllText(NotesPath);

                var process = System.Diagnostics.Process.Start("notepad.exe", NotesPath);

                process.WaitForExit();

                string newText = File.ReadAllText(NotesPath);

                if (newText != originalText)
                    MessageBox.Show("Редактирование успешно завершено");
                else
                    MessageBox.Show("Записи не были изменены");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть блокнот: " + ex.Message);
            }
        }


        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var win = new LoginWindow
            {
                Owner = this
            };
            win.ShowDialog();
        }
    }
}
