using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CourseStor.AAA.Pages.Account
{
    public class LoginModel(SignInManager<IdentityUser> signInManager) : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager = signInManager;

        [BindProperty]
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = " Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        [BindProperty]
        public string? returnUrl { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(UserName, Password, true, false);
                if (result.Succeeded)
                {
                    return Redirect(returnUrl ?? "/");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User or Password!");
                }
            }
            return Page();
        }
    }
}
