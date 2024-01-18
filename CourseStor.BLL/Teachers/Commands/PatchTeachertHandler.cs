using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Comments.Commands;
using CourseStor.Models.Comments.Entities;
using CourseStor.Models.Teachers.Commands;
using CourseStor.Models.Teachers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Teachers.Commands
{
    public class PatchTeachertHandler : BaseApplicationServiceHandler<PatchTeacher, Teacher>
    {
        public PatchTeachertHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(PatchTeacher request, CancellationToken cancellationToken)
        {
            var teacher = _context.Teachers.SingleOrDefault(c => c.Id == request.Id);
            if (teacher != null)
            {
                teacher.FirstName = request.FirstName;
                teacher.LastName = request.LastName;
                await _context.SaveChangesAsync();
                AddResult(teacher);
            }
            else
            {
                AddError($"Teacher with {request.Id} not found!");
            }
        }
    }
}
