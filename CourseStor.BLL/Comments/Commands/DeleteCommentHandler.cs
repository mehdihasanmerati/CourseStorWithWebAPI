using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Comments.Commands;
using CourseStor.Models.Comments.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Comments.Commands
{
    public class DeleteCommentHandler : BaseApplicationServiceHandler<DeleteComment, Comment>
    {
        public DeleteCommentHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(DeleteComment request, CancellationToken cancellationToken)
        {
            var comment = _context.Comments.SingleOrDefault(c => c.Id == request.Id);
            if (comment == null)
            {
                AddError($"The Id {comment.Id} not found!");
            }
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            AddResult(comment);
        }
    }
}
