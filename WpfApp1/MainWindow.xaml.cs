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

        private WorkWithData _workWithData;
        private WorkWithImage _workWithImage;

        public MainWindow()
        {
            InitializeComponent();

            _workWithData = new WorkWithData();
            _workWithImage = new WorkWithImage();
        }

        private void ShowAnswer(object sender, RoutedEventArgs e)
        {
            var count = _workWithData.CountQuestion;
            try
            {
                var image = _workWithImage.FindPhoto(count);
                img.Source = image;
                img.Visibility = Visibility.Visible;
            }
            catch (System.Exception)
            {

            }
        }

        private void NextAnswer_Button(object sender, RoutedEventArgs e)
        {
            _workWithData.CountQuestion++;

            var count = _workWithData.CountQuestion;

            QuestionText.Text = _workWithData.GetQuestion(count);
            img.Visibility = Visibility.Collapsed;
        }
    }
}
