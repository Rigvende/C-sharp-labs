using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace Lab9_Students.Infrastucture
{
    class ImageSourceConverter : IValueConverter
    {
        string ImageDirectory
        {
            get
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "images");
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Path.Combine(ImageDirectory, (string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

}
