using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Courses.Commands;
using CourseStor.Models.Courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Courses.Commands
{
    public class DeleteCourseHandler : BaseApplicationServiceHandler<DeleteCourse, Course>
    {
        public DeleteCourseHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(DeleteCourse request, CancellationToken cancellationToken)
        {
            var course = _context.Courses.SingleOrDefault(c=> c.Id == request.Id);
            if(course == null)
            {
                AddError($"Tag with {request.Id} not found");
            }

            _context.Courses.Remove(course);
           await _context.SaveChangesAsync();

            AddResult(course);
        }
    }
}
