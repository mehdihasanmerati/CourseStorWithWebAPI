using Microsoft.AspNetCore.Identity;

namespace CourseStor.AAA.Infrastructure
{
    public class UserNameInPasswordValidator : IPasswordValidator<IdentityUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager, IdentityUser user, string? password)
        {
            if (password.Contains(user.UserName, StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "UserNameInPassword",
                    Description = "You can not use UserName as Password"
                }));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
