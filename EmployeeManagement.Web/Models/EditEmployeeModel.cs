using System;
using System.ComponentModel.DataAnnotations;

using EmployeeManagement.Models;
using EmployeeManagement.Models.CustomValidators;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "FirstName must be provided")]
        [MinLength(2, ErrorMessage = "Atleast 2 character must be provided")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [EmailCustomValidator(AllowedDomain = "gmail.com",
            ErrorMessage = "gmail.com domain only allowed.")]
        public string Email { get; set; }
        [Compare("Email", ErrorMessage ="Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; } = new Department();
    }
}
