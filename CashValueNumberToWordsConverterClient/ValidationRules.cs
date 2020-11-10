using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace CashValueNumberToWordsConverterClient
{
    public class InputNumberValidationRule : ValidationRule
    {
        public double Min { get; set; }
        public double Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var inputString = value.ToString();
            if (!double.TryParse(value.ToString(), out double input))
            {
                return new ValidationResult(false, $"Could not parse the input {inputString} into double between {Min} and {Max}! Please input only numbers within this limits!");
            }

            if (input < Min)
            {
                return new ValidationResult(false, $"Input {input:F2} is smaller than {Min}! Please input a number between between {Min} and {Max}!");
            }

            if (input > Max)
            {
                return new ValidationResult(false, $"Input {input:F2} is greater than {Max}! Please input a number between between {Min} and {Max}!");
            }

            return new ValidationResult(true, null);
        }
    }
}
