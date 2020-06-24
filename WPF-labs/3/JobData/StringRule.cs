using System.Globalization;
using System.Windows.Controls;

namespace JobData
{
    class StringRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if (value.ToString().Length == 0)
            {
                return new ValidationResult(false, "Не все поля заполнены!");
            }
            return ValidationResult.ValidResult;
        }
    }
}
