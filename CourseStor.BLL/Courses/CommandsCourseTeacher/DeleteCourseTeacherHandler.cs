using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Courses.CommandsTeacherCourse;
using CourseStor.Models.Courses.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Courses.CommandsCourseTeacher
{
    public class DeleteCourseTeacherHandler : ApplicationServiceHandler<DeleteCourseTeacher, CourseTeacher>
    {
        public DeleteCourseTeacherHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(DeleteCourseTeacher request, CancellationToken cancellationToken)
        {
            var courseTeacher = _context.CourseTeachers.SingleOrDefault(c => c.Id == request.Id);
            if (courseTeacher == null)
                AddError($"The Id with {request.Id} is not found!");

            _context.CourseTeachers.Remove(courseTeacher);
            await _context.SaveChangesAsync();

            AddResult(courseTeacher);


        }
    }
}
