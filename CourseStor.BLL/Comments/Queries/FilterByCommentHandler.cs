using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.DAL.Frameworks;
using CourseStor.Models.Comments.Dto;
using CourseStor.Models.Comments.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Comments.Queries
{
    public class FilterByCommentHandler : ApplicationServiceHandler<FilteByComment, List<CommentQueryResult>>
    {
        public FilterByCommentHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(FilteByComment request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.WhereOverComment(request.Id).ToQueryCommentAsync();
            AddResult(comment);
        }
    }
}
