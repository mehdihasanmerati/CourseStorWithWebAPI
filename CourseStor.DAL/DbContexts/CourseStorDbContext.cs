using CourseStor.Models.Comments.Entities;
using CourseStor.Models.Courses.Entities;
using CourseStor.Models.Orders.Entities;
using CourseStor.Models.Tags.Entities;
using CourseStor.Models.Teachers.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.DAL.DbContexts
{
    public class CourseStorDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTag> CourseTags { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public CourseStorDbContext(DbContextOptions<CourseStorDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(item.ClrType).Property<string>("CreateBy").HasMaxLength(50);
                modelBuilder.Entity(item.ClrType).Property<string>("UpdateBy").HasMaxLength(50);
                modelBuilder.Entity(item.ClrType).Property<DateTime>("CreateDate").HasMaxLength(50);
                modelBuilder.Entity(item.ClrType).Property<DateTime>("UpdateDate").HasMaxLength(50);
            }
        }
    }
}
