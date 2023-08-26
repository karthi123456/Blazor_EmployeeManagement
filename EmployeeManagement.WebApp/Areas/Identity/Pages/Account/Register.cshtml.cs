using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

using EmployeeManagement.WebApp.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagement.WebApp.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly CustomAuthService _auth;
        public RegisterModel(CustomAuthService _auth)
        {
            this._auth = _auth;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");
            if (ModelState.IsValid)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Input.Email),
                    new Claim(ClaimTypes.Email, Input.Email),
                    new Claim("city", Input.City),
                    new Claim("password", Input.Password),
                    new Claim(ClaimTypes.Role, Input.Role)
                };

                var claimsIdentity = new ClaimsIdentity(claims, 
                        CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(claimsIdentity);

                _auth.Users.Add(Input.Email, principal);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                            principal);

                return LocalRedirect(ReturnUrl);
            }
            
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

            [Required]
            public string City { get; set; }

            [Required]
            public string Role { get; set; }
        }
    }
}
