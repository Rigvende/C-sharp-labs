using System;
using System.Globalization;
using System.Windows.Data;

namespace Lab9_Students.Infrastucture
{
    class IndividualPriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Оплата (с учётом скидки): " + Math.Round(((decimal)value), 2, MidpointRounding.AwayFromZero).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

}
