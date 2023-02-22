using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int _cz = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage image = new BitmapImage();

            var fileName = _cz + ".png";

            using (FileStream stream = File.OpenRead(@"C:\Project\PreparationByFormulas\PreparationByFormulas\Image\" + fileName))
            {
                image.BeginInit();
                image.StreamSource = stream;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
            }

            _cz++;

            img.Source = image;
        }

    }
}
