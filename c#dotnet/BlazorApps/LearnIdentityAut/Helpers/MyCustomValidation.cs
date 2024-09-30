using System.ComponentModel.DataAnnotations;

namespace LearnIdentityAut.Helpers
{
    public class MyCustomValidation : ValidationAttribute
    {
        public string Text { get; set; }

        public MyCustomValidation(string _text)
        {
            Text = _text;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string bookname = value.ToString();
                if (bookname.Contains(Text))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? "Book does not contain MVC in it");
        }

    }
}
