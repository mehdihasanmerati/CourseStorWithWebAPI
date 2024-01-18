using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Comments.Commands;
using CourseStor.Models.Comments.Entities;

namespace CourseStor.BLL.Comments.Commands
{
    public class PatchCommandHandler : BaseApplicationServiceHandler<PatchComment, Comment>
    {
        public PatchCommandHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(PatchComment request, CancellationToken cancellationToken)
        {
            var comment = _context.Comments.SingleOrDefault(c=> c.Id == request.Id);
            if (comment != null)
            {
                comment.Comments = request.Comments;
                comment.CommentBy = request.CommentBy;
                comment.StarRate = request.StarRate;
                comment.CourseId = request.CourseId;
                await _context.SaveChangesAsync();
                AddResult(comment);
            }
            else
            {
                AddError($"The Course or Order with {request.Id} and {request.CourseId} does not exist or is wrong! or other field is required. Try again please.");
            }
        }
    }
}
