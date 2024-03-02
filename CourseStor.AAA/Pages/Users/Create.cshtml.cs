using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CourseStor.AAA.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateModel(UserManager<IdentityUser> userManager) : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty,EmailAddress]
        public string Email { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new()
                {
                    UserName = UserName,
                    Email = Email
                };
               var result = await _userManager.CreateAsync(user, Password);
                if (result.Succeeded)
                {
                    return RedirectToPage("List");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return Page();
        }
    }
}
