using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Courses.CommandsTeacherCourse;
using CourseStor.Models.Courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Courses.CommandsTeacherCourse
{
    public class CreateTeacherCourseHandler : BaseApplicationServiceHandler<CreateCourseTeacher, CourseTeacher>
    {
        public CreateTeacherCourseHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(CreateCourseTeacher request, CancellationToken cancellationToken)
        {
            try
            {
                CourseTeacher courseTeacher = new CourseTeacher()
                {
                    SortOrder = request.SortOrder,
                    TeacherId = request.TeacherId,
                    CourseId = request.CourseId
                };
                await _context.CourseTeachers.AddAsync(courseTeacher);
                await _context.SaveChangesAsync();

                AddResult(courseTeacher);
            }
            catch (Exception)
            {

                AddError("The Id from Course or Teacher is wrong!");
            }
            
        }
    }
}
