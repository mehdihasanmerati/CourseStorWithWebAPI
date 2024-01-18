using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Courses.CommandsCourseTeacher;
using CourseStor.Models.Courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Courses.CommandsCourseTeacher
{
    public class PatchCourseTeacherHandler : BaseApplicationServiceHandler<PatchCourseTeacher, CourseTeacher>
    {
        public PatchCourseTeacherHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(PatchCourseTeacher request, CancellationToken cancellationToken)
        {
            var courseTeacher = _context.CourseTeachers.SingleOrDefault(c=> c.Id == request.Id);
            if (courseTeacher != null)
            {
                courseTeacher.SortOrder = request.SortOrder;
                courseTeacher.TeacherId = request.TeacherId;
                courseTeacher.CourseId = request.CourseId;
                await _context.SaveChangesAsync();
                AddResult(courseTeacher);
            }
            else
            {
                AddError($"The CourseTeachersId with {request.Id} or CourseId with {request.CourseId} or TeacherId with {request.TeacherId} are not found or exist!");

            }
        }
    }
}
