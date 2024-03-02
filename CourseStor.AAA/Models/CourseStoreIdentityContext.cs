using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CourseStor.AAA.Models
{
    public class CourseStoreIdentityContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<BadPassword> BadPasswords { get; set; }
        public CourseStoreIdentityContext(DbContextOptions<CourseStoreIdentityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BadPassword>().HasKey(x => x.Id);
        }
    }
}
