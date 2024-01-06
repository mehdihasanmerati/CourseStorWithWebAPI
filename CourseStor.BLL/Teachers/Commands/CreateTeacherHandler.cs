using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Teachers.Commands;
using CourseStor.Models.Teachers.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Teachers.Commands
{
    public class CreateTeacherHandler : BaseApplicationServiceHandler<CreateTeacher, Teacher>
    {
        public CreateTeacherHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(CreateTeacher request, CancellationToken cancellationToken)
        {
            Teacher teacher = new Teacher()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };
           await _context.Teachers.AddAsync(teacher);
           await _context.SaveChangesAsync();

           AddResult(teacher);
        }
    }
}
