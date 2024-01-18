using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Courses.Commands;
using CourseStor.Models.Courses.Entities;

namespace CourseStor.BLL.Courses.Commands
{
    public class UpdateCourseHandler : BaseApplicationServiceHandler<UpdateCourse, Course>
    {
        public UpdateCourseHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(UpdateCourse request, CancellationToken cancellationToken)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == request.Id);
            if (course == null)
            {
                AddError($"Tag with {request.Id} not found");
            }
            else
            {
                course.Title = request.Title;
                course.ShortDescription = request.ShortDescription;
                course.Price = (double)request.Price;
                course.CreateDateCorse =(DateTime)request.CreateDateCorse;
                await _context.SaveChangesAsync();
                AddResult(course);
            }
        }
    }
}
