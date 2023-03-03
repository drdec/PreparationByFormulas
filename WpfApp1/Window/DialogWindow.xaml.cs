using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public bool IsRandom { get; set; }
        public bool IsTimeUse { get; set; }
        public DialogWindow()
        {
            InitializeComponent();
            Title = "Настройки тренировки формул";
            IsRandom = false;
            IsTimeUse = false;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            IsRandom = (bool)RandomQuestion.IsChecked;
            IsTimeUse = (bool)UseTime.IsChecked;

            Close();
        }
    }
}
