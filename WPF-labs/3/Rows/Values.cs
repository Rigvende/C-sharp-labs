using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Rows
{
    class Values : INotifyPropertyChanged
    {
        private double _XStart;
        private double _XStop;
        private double _step;
        private int _N;

        public double XStart
        {
            get
            {
                return _XStart;
            }
            set
            {
                bool result = double.TryParse(value.ToString(), out double convertedValue);
                if (result && convertedValue < 1 && convertedValue > -1)
                {
                    _XStart = convertedValue;
                    OnPropertyChanged("XStart");
                }
            }
        }

        public double XStop
        {
            get
            {
                return _XStop;
            }
            set
            {
                bool result = double.TryParse(value.ToString(), out double convertedValue);

                if (result && convertedValue < 1 && convertedValue > -1)
                {
                    _XStop = convertedValue;
                    OnPropertyChanged("XStop");
                }
            }
        }

        public double Step
        {
            get
            {
                return _step;
            }
            set
            {
                bool result = double.TryParse(value.ToString(), out double convertedValue);
                MessageBox.Show(value.ToString());
                if (result && convertedValue < 1)
                {
                    _step = convertedValue;
                    OnPropertyChanged("step");
                }
            }
        }

        public double N
        {
            get
            {
                return _N;
            }
            set
            {
                bool result = int.TryParse(value.ToString(), out int convertedValue);
                if (result && convertedValue > 1)
                {
                    _N = convertedValue;
                    OnPropertyChanged("N");
                }
            }
        }

        public Values()
        {
            _XStart = 0;
            _XStop = 0;
            _step = 0.1;
            _N = 2;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void GetResults(ObservableCollection<string> results)
        {
            double xStart = XStart;
            double xStop = XStop;
            while (xStart <= xStop)
            {
                int k = 1;
                double sum = 0;
                while (k <= N)
                {
                    sum += Math.Pow(-1, k - 1) * Math.Sin(k * xStart) / k;
                    k += 1;
                }
                string resString = $"S({xStart}) = {sum}";
                results.Add(resString);
                double result = xStart / 2;
                results.Add($"Y({xStart}) = {result}");
                xStart += Step;
            }
        }
    }
}
