using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CrazyButton
{
    public partial class MainWindow : Window
    {
        readonly Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonYes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(this);
            Canvas.SetLeft(yes, point.X - yes.ActualWidth / 2);
            Canvas.SetTop(yes, point.Y - yes.ActualHeight / 2);
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Отлично!");
        }

        private void ButtonNo_MouseMove(object sender, MouseEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                return;
            }
            _ = e.GetPosition(this);
            Canvas.SetLeft(no, random.NextDouble() * ((Content as Canvas).ActualWidth - 50));
            Canvas.SetTop(no, random.NextDouble() * ((Content as Canvas).ActualHeight - 50));
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Не торопитесь, подумайте.");
        }
    }
}
