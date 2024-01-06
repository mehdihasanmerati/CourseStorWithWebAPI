using Azure.Core;
using CourseStor.BLL.Frameworks;
using CourseStor.BLL.Teachers.Commands;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Courses.CommandsTeacherCourse;
using CourseStor.Models.Courses.Entities;
using CourseStor.Models.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Courses.CommandsCourseTeacher
{
    public class UpdateTeacherCourseHandel : BaseApplicationServiceHandler<UpdateCourseTeacher, CourseTeacher>
    {
        public UpdateTeacherCourseHandel(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(UpdateCourseTeacher request, CancellationToken cancellationToken)
        {
            var courseTeacher = _context.CourseTeachers.SingleOrDefault(c => c.Id == request.Id && c.CourseId == request.CourseId &&
            c.TeacherId == request.TeacherId);

            if (courseTeacher == null)
            {
                AddError($"The CourseTeachersId with {request.Id} or CourseId with {request.CourseId} or TeacherId with {request.TeacherId} are not found or exist!");
            }
            else
            {
                courseTeacher.Id = request.Id;
                courseTeacher.SortOrder = request.SortOrder;
                courseTeacher.TeacherId = request.TeacherId;
                courseTeacher.CourseId = request.CourseId;
                await _context.SaveChangesAsync();
                AddResult(courseTeacher);
            }

        }

    }

}
