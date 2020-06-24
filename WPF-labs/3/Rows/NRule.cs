using System.Globalization;
using System.Windows.Controls;

namespace Rows
{
    class NRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int convertedValue;

            try
            {
                convertedValue = int.Parse((string)value);
            }
            catch
            {
                return new ValidationResult(false, "Введите целое число N");
            }

            if (convertedValue <= 0)
            {
                return new ValidationResult(false, "Количество меньше 0");
            }
            return ValidationResult.ValidResult;
        }
    }
}