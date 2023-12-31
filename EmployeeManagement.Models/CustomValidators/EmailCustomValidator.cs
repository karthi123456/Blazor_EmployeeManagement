﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.CustomValidators
{
    public class EmailCustomValidator : ValidationAttribute
    {
        public string AllowedDomain { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string[] strings = value.ToString().Split('@');
                if (strings.Length > 1 && strings[1].ToUpper() == AllowedDomain.ToUpper())
                    return null;

                //return new ValidationResult($"Domain must be {AllowedDomain}",
                //    new[] { validationContext.MemberName });

                /* ErrorMessge property using to common model provide ErrorMessage from Model class */
                return new ValidationResult(ErrorMessage,
                    new[] { validationContext.MemberName });
            }
            return null;
        }
    }
}
