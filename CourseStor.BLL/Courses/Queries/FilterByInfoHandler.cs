using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.DAL.Frameworks;
using CourseStor.Models.Courses.Dto;
using CourseStor.Models.Courses.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Courses.Queries
{
    public class FilterByInfoHandler : ApplicationServiceHandler<FilterByInfo, List<CourseQueryResult>>
    {
        public FilterByInfoHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(FilterByInfo request, CancellationToken cancellationToken)
        {
            var result = await _context.Courses.WhereOverCourse(request.Title, request.Id).ToQueryCourseAsync();
            AddResult(result);
        }
    }
}
