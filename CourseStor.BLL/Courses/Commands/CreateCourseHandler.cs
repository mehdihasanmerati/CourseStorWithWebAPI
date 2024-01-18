using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Courses.Commands;
using CourseStor.Models.Courses.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Courses.Commands
{
    public class CreateCourseHandler : BaseApplicationServiceHandler<CreateCourse, Course>
    {
        public CreateCourseHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected async override Task HandleRequest(CreateCourse request, CancellationToken cancellationToken)
        {
            Course course = new Course
            {
                Title = request.Title,
                ShortDescription = request.ShortDescription,
                Price = (double)request.Price,
                CreateDateCorse =(DateTime) request.CreateDateCorse
            };
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            AddResult(course);
        }
    }
}
