using System.Globalization;
using System.Windows.Controls;

namespace Rows
{
    class StepRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double convertedValue;

            try
            {
                convertedValue = double.Parse((string)value, new NumberFormatInfo());
            }
            catch
            {
                return new ValidationResult(false, "Недопустимое значение");
            }

            if (convertedValue <= 0)
            {
                return new ValidationResult(false, "Шаг меньше или равен 0");
            }
            return ValidationResult.ValidResult;
        }
    }
}
