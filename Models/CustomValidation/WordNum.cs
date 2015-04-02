using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MVC01.Models.CustomValidation
{
    public class WordNum : ValidationAttribute
    {
        private readonly int _length;

        public WordNum(int length)
            : base("product name cannot have more  than {0} words")
        {
            _length = length;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string valueAsString = value.ToString();
                string[] stArrayData = valueAsString.Split(' ');

                if (stArrayData.Length > _length)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}