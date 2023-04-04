using Mathematik3DVektorenApp.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Mathematik3DVektorenApp.Validation
{
    /// <summary>
    /// Here is a way to validate a control's input from the user by
    /// generelasing the abstarct class "ValidationRule" with overriding the method "Validate"
    /// with our own logic using the RegEx class features and the method "IsMatch"
    /// there are other ways to do validation
    /// ex. implementing the INotifyDataErrorInfo interface and customize/override  templates and styles.
    /// </summary>
    public class InputValidator : ValidationRule
    {

        string userInputPattern = @"^[-+]?[0-9]*[.,]?[0-9]+$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            switch (value.ToString())
            {
                case string input when !Regex.IsMatch(input, userInputPattern,RegexOptions.CultureInvariant):
                    return new ValidationResult(false, "This is a wrong input! please check the value again");

                default:
                    return ValidationResult.ValidResult;
            }
        }
    }
}
