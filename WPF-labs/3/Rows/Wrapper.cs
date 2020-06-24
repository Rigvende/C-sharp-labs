using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Rows
{
    public class Wrapper : DependencyObject
    {
        public static readonly DependencyProperty StartProperty =
             DependencyProperty.Register("start", typeof(double),
             typeof(Wrapper), new FrameworkPropertyMetadata(null));

        public double start
        {
            get { return (double)GetValue(StartProperty); }
            set { SetValue(StartProperty, value); }
        }
    }

    class XStopRule : ValidationRule
    {
        public Wrapper Wrapper { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double convertedValue;
            try
            {
                convertedValue = double.Parse((string)value, new NumberFormatInfo());
            }
            catch
            {
                return new ValidationResult(false, "Вы ввели недопустимые значения");
            }
            if (convertedValue < Wrapper.start)
            {

                return new ValidationResult(false, "Конечное значение аргумента меньше начального значения");
            }
            if (convertedValue >= 1 && convertedValue <= -1)
            {

                return new ValidationResult(false, "Конечное значение аргумента больше или равно 1 или меньше или равно -1");
            }
            return ValidationResult.ValidResult;
        }
    }
}
