using CourseStor.Models.Teachers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.DAL.Teachers
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(c=> c.FirstName).HasMaxLength(50);
            builder.Property(c => c.LastName).HasMaxLength(50);
        }
    }
}
