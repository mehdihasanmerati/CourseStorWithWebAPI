using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CourseStor.AAA.Pages.Users
{
    [Authorize(Policy = "IsAdmin")]
    public class EditModel(UserManager<IdentityUser> userManager) : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;

        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty, EmailAddress]
        public string Email { get; set; }
        [BindProperty]
        public string? Password { get; set; }

        public async Task OnGetAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            UserName = user.UserName;
            Email = user.Email;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(Id);
                user.UserName = UserName;
                user.Email = Email;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded && !string.IsNullOrEmpty(Password))
                {
                    await _userManager.RemovePasswordAsync(user);
                    result = await _userManager.AddPasswordAsync(user, Password);
                }
                if (result.Succeeded)
                {
                    return RedirectToPage("List");
                }
            }
            return Page();
        }
    }
}
