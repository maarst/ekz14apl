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
using System.IO;
namespace Blocnot.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditorWindow.xaml
    /// </summary>
    public partial class EditorWindow : Window
    {
        public enum EditorMode { AppendLine, EditFile }
        public EditorMode Mode { get; set; } = EditorMode.AppendLine;
        private readonly bool _isSingleLine;
        private string _originalText = string.Empty;

        public EditorWindow(bool isSingleLine)
        {
            InitializeComponent();
            _isSingleLine = isSingleLine;
            if (_isSingleLine)
            {
                TxtEditor.AcceptsReturn = false;
                TxtEditor.Height = 30;
                TxtEditor.TextWrapping = TextWrapping.NoWrap;
                TxtHint.Text = "Введите одну строку и нажмите Сохранить:";
            }
            else
            {
                TxtHint.Text = "Редактирование файла заметок:";
                LoadFile();
            }
        }


        private void LoadFile()
        {
            try
            {
                if (File.Exists(MainWindow.NotesPath))
                {
                    _originalText = File.ReadAllText(MainWindow.NotesPath);
                    TxtEditor.Text = _originalText;
                }
                else
                {
                    _originalText = string.Empty;
                    TxtEditor.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения файла: " + ex.Message);
            }
        }


        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Mode == EditorMode.AppendLine || _isSingleLine)
                {
                    var line = TxtEditor.Text.Replace("\r", "").Replace("\n", "").Trim();

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        MessageBox.Show("Строка пустая, ничего не сохранено.");
                        return;
                    }

                    File.AppendAllText(MainWindow.NotesPath, line + Environment.NewLine);

                    MessageBox.Show("Строка успешно сохранена.");
                    this.Close();
                    return;
                }

                string newText = TxtEditor.Text;

                if (newText == _originalText)
                {
                    MessageBox.Show("Записи не были изменены");
                }
                else
                {
                    File.WriteAllText(MainWindow.NotesPath, newText);
                    MessageBox.Show("Редактирование успешно завершено");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message);
            }
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
