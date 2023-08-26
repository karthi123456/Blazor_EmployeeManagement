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

    public class LoginModel : PageModel
    {
        private readonly CustomAuthService _auth;
        public LoginModel(CustomAuthService _auth)
        {
            this._auth = _auth;
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
                ClaimsPrincipal principal;
                _auth.Users.TryGetValue(Input.Email, out principal);

                if (principal == null)
                {
                    ModelState.AddModelError("ErrorMessage",
                            "UserName is not valid");

                    return Page();
                }

                var identity = principal.Identity as ClaimsIdentity;
                var userName = identity.FindFirst(ClaimTypes.Name)?.Value;
                var passWord = identity.FindFirst("password")?.Value;

                if (userName == Input.Email && passWord == Input.Password)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                        principal);

                    return LocalRedirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("ErrorMessage",
                                "Incorrect Password");
                    return Page();
                }
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
