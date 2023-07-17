using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfApp1.Service;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private WorkWithData _workWithData;
        private WorkWithImage _workWithImage;
        private int cz;

        public MainWindow()
        {
            Inizialize();
            cz = 0;

            //InitializeComponent();

            //var window = new DialogWindow();
            //window.ShowDialog();

            //try
            //{
            //    _workWithData = new WorkWithData(window.IsRandom, window.IsTimeUse);
            //    _workWithImage = new WorkWithImage();
            //}
            //catch (FileNotFoundException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    Process.GetCurrentProcess().Kill();
            //}

            //MessageBox.Show(window.IsTimeUse + " " + window.IsRandom);
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Inizialize();
        }

        private void Inizialize()
        {
            InitializeComponent();

            QuestionText.Text = "Здесь будет отображаться вопрос";
            img.Visibility = Visibility.Collapsed;

            var window = new DialogWindow();
            window.ShowDialog();


            try
            {
                _workWithData = new WorkWithData(window.IsRandom, window.IsTimeUse);
                _workWithImage = new WorkWithImage();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                Process.GetCurrentProcess().Kill();
            }
        }

        private void ShowAnswer(object sender, RoutedEventArgs e)
        {
            //var count = _workWithData.NumberOfImage;
            //try
            //{
            //    var image = _workWithImage.FindPhoto(count);
            //    img.Source = image;
            //    img.Visibility = Visibility.Visible;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            ShowAnswer();
        }

        private void ShowAnswer_Key(object sender, KeyEventArgs key)
        {
            if (key.Key == Key.Enter)
            {
                ShowAnswer();
            }
        }

        private void ShowAnswer()
        {
            var count = _workWithData.NumberOfImage;
            try
            {
                var image = _workWithImage.FindPhoto(count);
                img.Source = image;
                img.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NextAnswer_Button(object sender, RoutedEventArgs e)
        {
            _workWithData.CountQuestion++;

            GetAnswer();
        }

        private void ButtonPreviousQuestion(object sender, RoutedEventArgs e)
        {
            _workWithData.CountQuestion--;

            GetAnswer();
        }

        private void GetAnswer()
        {
            QuestionText.Text = _workWithData.GetQuestion();
            img.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cz++;
            CzTextBox.Text = cz.ToString();
        }
    }
}
