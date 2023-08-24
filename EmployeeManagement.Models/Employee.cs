using System;
using System.ComponentModel.DataAnnotations;

using EmployeeManagement.Models.CustomValidators;

namespace EmployeeManagement.Models
{
   public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="FirstName must be provided")]
        [MinLength(2, ErrorMessage ="Atleast 2 character must be provided")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [EmailCustomValidator(AllowedDomain = "gmail.com", 
            ErrorMessage ="gmail.com domain only allowed.")]
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }
    }
}