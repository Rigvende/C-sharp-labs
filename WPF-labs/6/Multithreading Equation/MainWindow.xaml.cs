using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Multithreading_Equation
{
    public partial class MainWindow : Window
    {
        EquationSettings settings;

        public MainWindow()
        {

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenSettings();
        }

        private void OpenSettings()
        {
            settings = new EquationSettings
            {
                Owner = this
            };
            settings.Show();
        }

        private void CommandCalculateExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (settings == null)
            {
                settings = new EquationSettings
                {
                    Owner = this
                };
            }
            try
            {
                if (settings.A == 0.0 && settings.B == 0.0 && settings.N == 0.0)
                {
                    throw new Exception("Не заполнены данные!");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
                getResult.IsEnabled = false;
            setData.IsEnabled = false;
            settings.ButtonEnable(false);
            progressBar.Maximum = settings.N;
            Thread thread = new Thread(Calculate);
            thread.Start();
        }

        public void Calculate()
        {
            double A = settings.A;
            double B = settings.B;
            double N = settings.N;
            double H = (B - A) / N;
            double X = 0.0;
            try
            {
                for (int I = 1; I < N; I++)
                {
                    double root = A + H * I;
                    X += Math.Pow(root, 4);
                    Dispatcher.Invoke(new Action(() =>
                    {
                        progressBar.Value = I + 1;
                        textBar.Content = string.Format("{0:f0}%", (I + 1) * 100 / N);
                    }));                
                }
            }
            catch (System.Threading.Tasks.TaskCanceledException E)
            {
                MessageBox.Show(E.Message);
            }
            double result = H * X;
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                resultField.Text = string.Format("{0:f2}", result);
                getResult.IsEnabled = true;
                setData.IsEnabled = true;
                settings.ButtonEnable(true);
            });
        }

    }

}
