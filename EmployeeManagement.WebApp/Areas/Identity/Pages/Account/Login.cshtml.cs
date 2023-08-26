using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagement.WebApp.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> _signInManager)
        {
            this._signInManager = _signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");
            
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email,
                    Input.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                    return LocalRedirect(ReturnUrl);
            }

            ModelState.AddModelError("ErrorMessage", 
                "Incorrect Username and Password");
            
            return Page();
        }
        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
