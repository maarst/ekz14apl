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
using System.Windows.Threading;
using System.Timers;

namespace _29012029
{
    /// <summary>
    /// Логика взаимодействия для ThirdWindow.xaml
    /// </summary>
    public partial class ThirdWindow : Window
    {
        private DispatcherTimer _timer; //таймер на 2 сек
        private bool _isImageOne = true;  

        public ThirdWindow()
        {
            InitializeComponent();

            _timer = new DispatcherTimer(DispatcherPriority.Send);
            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += Timer_Tick;
            this.Closed += ThirdWindow_Closed;
        }

        private void ChangeImage()
        {
            _isImageOne = !_isImageOne;
            string imgName;

            if (_isImageOne == true)
            {
                imgName = "img1.jpg";
            }
            else
            {
                imgName = "img2.jpg";
            }

            DynamicImage.Source = new BitmapImage(new Uri(imgName, UriKind.RelativeOrAbsolute));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ChangeImage();
        }

        private void DynamicImage_Clicking(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Check2.IsChecked == true)
            {
                ChangeImage(); 

                MessageBox.Show("Изображение изменено");

                if (Check1.IsChecked == true)
                {
                    _timer.Stop();
                    _timer.Start();
                }
            }
        }

        private void Check1_Checked(object sender, RoutedEventArgs e)
        {
            _timer.Start();
        }

        private void Check1_Unchecked(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }

        private void ThirdWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

