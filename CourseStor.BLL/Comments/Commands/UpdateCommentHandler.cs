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
    public class UpdateCommentHandler : BaseApplicationServiceHandler<UpdateComment, Comment>
    {
        public UpdateCommentHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(UpdateComment request, CancellationToken cancellationToken)
        {
            var comment = _context.Comments.SingleOrDefault(c => c.Id == request.Id);


            if (comment == null)
            {
                AddError($"The CommentId or CourseId with {request.Id} and {request.CourseId} is not exist or wrong! or other field is required.Try Again Please. ");
            }
            else
            {
                comment.Id = request.Id;
                comment.CourseId = request.CourseId;
                comment.Comments = request.Comments;
                comment.CommentBy = request.CommentBy;
                comment.StarRate = request.StarRate;
                await _context.SaveChangesAsync();
                AddResult(comment);
            }


        }
    }
}
