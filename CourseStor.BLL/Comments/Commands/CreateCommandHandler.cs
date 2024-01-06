using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Comments.Commands;
using CourseStor.Models.Comments.Entities;

namespace CourseStor.BLL.Comments.Commands
{
    public class CreateCommandHandler : BaseApplicationServiceHandler<CreateComment, Comment>
    {
        public CreateCommandHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(CreateComment request, CancellationToken cancellationToken)
        {
            Comment comment = new Comment()
            {
                CommentBy = request.CommentBy,
                Comments = request.Comments,
                StarRate = request.StarRate,
                CourseId = request.CourseId,
            };
            try
            {
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
                AddResult(comment);
            }
            catch (Exception)
            {
                AddError($"the Course with Id {comment.CourseId} no found! Try Again Please");
            }

        }
    }
}
