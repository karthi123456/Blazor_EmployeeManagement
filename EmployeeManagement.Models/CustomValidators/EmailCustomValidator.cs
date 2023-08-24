using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.CustomValidators
{
    public class EmailCustomValidator : ValidationAttribute
    {
        public string AllowedDomain { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] strings = value.ToString().Split('@');
            if (strings[1].ToUpper() == AllowedDomain.ToUpper())
                return null;

            //return new ValidationResult($"Domain must be {AllowedDomain}",
            //    new[] { validationContext.MemberName });

            /* ErrorMessge property using to common model provide ErrorMessage from Model class */
            return new ValidationResult(ErrorMessage,
                new[] { validationContext.MemberName });
        }
    }
}
