using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.DAL.Frameworks;
using CourseStor.Models.Frameworks;
using CourseStor.Models.Tags.Dto;
using CourseStor.Models.Tags.Quries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Tags.Queries
{
    public class FilterByNameHandler : ApplicationServiceHandler<FilterByName, List<TagQueryResult>>
    {
        public FilterByNameHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(FilterByName request, CancellationToken cancellationToken)
        {
            var result = await _context.Tags.WhereOver(request.TagName, request.Id).ToQueryResultAsync();
            AddResult(result);
        }

        
    }


}
