using Microsoft.AspNetCore.Identity;

namespace CourseStor.AAA.Infrastructure
{
    public class CustomUserValidator : IUserValidator<IdentityUser>
    {
        private readonly string OrganizationEmail = "@course.com";
        public Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager, IdentityUser user)
        {
            if (!user.Email.EndsWith(OrganizationEmail,StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "CustomUserValidator",
                    Description = "Your email should be end with OrganizationEmail"
                }));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
