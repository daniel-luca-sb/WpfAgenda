using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfAgenda1
{
    public class PhoneValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var tel = value as string;
            if (tel.All<char>(c => char.IsDigit(c)))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Telefonul trebuie sa contina doar cifre");
            }
        }
    }
}
