using CourseStor.AAA.Models;
using Microsoft.AspNetCore.Identity;

namespace CourseStor.AAA.Infrastructure
{
    public class InvalidPassword<TUser> : IPasswordValidator<TUser> where TUser : IdentityUser
    {
        private readonly CourseStoreIdentityContext _context;

        public InvalidPassword(CourseStoreIdentityContext context)
        {
            _context = context;
        }
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string? password)
        {
            if (_context.BadPasswords.ToList().Any(c=> string.Equals(c.Password, password,StringComparison.OrdinalIgnoreCase)))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "InvalidPassword",
                    Description = "You can not use in BlackList"
                }));
            }
            return Task.FromResult(IdentityResult.Success);
        }

    }
}
