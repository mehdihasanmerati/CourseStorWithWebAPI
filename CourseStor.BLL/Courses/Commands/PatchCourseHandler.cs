using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Courses.Commands;
using CourseStor.Models.Courses.Entities;
using CourseStor.Models.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Courses.Commands
{
    public class PatchCourseHandler : BaseApplicationServiceHandler<PatchCourse, Course>
    {
        public PatchCourseHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(PatchCourse request, CancellationToken cancellationToken)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == request.Id);
            if (course != null)
            {
                course.Title = request.Title;
                course.ShortDescription = request.ShortDescription;
                course.Price = (double?)request.Price ?? 0 ;
                course.CreateDateCorse = (DateTime?)request.CreateDateCorse;
                await _context.SaveChangesAsync();
                AddResult(course);
            }
            else
            {
                AddError($"Teacher with {request.Id} not found!");
            }
        }
    }
}
