using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Tags.Commands;
using CourseStor.Models.Tags.Entities;

namespace CourseStor.BLL.Tags.Commands
{
    public class UpdateTagHandler : BaseApplicationServiceHandler<UpdateTag,Tag>
    {
        public UpdateTagHandler(CourseStorDbContext _context) : base(_context)
        {
        }

        protected override async Task HandleRequest(UpdateTag request, CancellationToken cancellationToken)
        {
            Tag tag = _context.Tags.SingleOrDefault(c => c.Id == request.Id);
            if (tag == null)
            {
                AddError($"Tag with {request.Id} not found!");
            }
            else
            {
                tag.TagName = request.TagName;
                await _context.SaveChangesAsync();
                AddResult(tag);
            }
        }
    }
}
