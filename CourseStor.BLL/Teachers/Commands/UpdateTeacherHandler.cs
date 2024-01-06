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
    public class UpdateTeacherHandler : BaseApplicationServiceHandler<UpdateTeacher, Teacher>
    {
        public UpdateTeacherHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(UpdateTeacher request, CancellationToken cancellationToken)
        {
            var teacher = _context.Teachers.SingleOrDefault(c=> c.Id == request.Id);
            if (teacher == null)
            {
                AddError($"Tag with {request.Id} not found!");
            }
            else
            {
                teacher.Id = request.Id;
                teacher.FirstName = request.FirstName;
                teacher.LastName = request.LastName;
                await _context.SaveChangesAsync();
                AddResult(teacher);
            }
        }
    }
}
