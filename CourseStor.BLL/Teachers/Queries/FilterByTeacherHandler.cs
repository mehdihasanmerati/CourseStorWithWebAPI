using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.DAL.Frameworks;
using CourseStor.Models.Teachers.Commands;
using CourseStor.Models.Teachers.Dto;
using CourseStor.Models.Teachers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Teachers.Queries
{
    public class FilterByTeacherHandler : ApplicationServiceHandler<FilterByTeacher, List<TeacherQueryResult>>
    {
        public FilterByTeacherHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(FilterByTeacher request, CancellationToken cancellationToken)
        {
            var responce = await _context.Teachers.WhereOverTeacher(request.Id.ToString()).ToQueryTeacherAsync();
            AddResult(responce);
        }
    }
}
