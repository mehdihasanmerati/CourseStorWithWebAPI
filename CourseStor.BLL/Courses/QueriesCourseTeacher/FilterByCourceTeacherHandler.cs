using CourseStor.BLL.Comments.Queries;
using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.DAL.Frameworks;
using CourseStor.Models.Courses.Entities;
using CourseStor.Models.Courses.QueriesCourseTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Courses.QueriesCourseTeacher
{
    public class FilterByCourceTeacherHandler : BaseApplicationServiceHandler<FilterByCourseTeacher, List<CourseTeacher>>
    {
        public FilterByCourceTeacherHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(FilterByCourseTeacher request, CancellationToken cancellationToken)
        {
            var responce = await _context.CourseTeachers.WhereOverCourseTeacher(request.Id).ToCourseTeacherQury();
            AddResult(responce);
        }
    }
}
