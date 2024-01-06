using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Tags.Commands;
using CourseStor.Models.Tags.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Tags.Commands
{
    public class DeleteTagHandler : BaseApplicationServiceHandler<DeleteTag, Tag>
    {
        public DeleteTagHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(DeleteTag request, CancellationToken cancellationToken)
        {
            var tag = _context.Tags.SingleOrDefault(c => c.Id == request.Id);
            if (tag == null)
            {
                AddError($"Tag with {request.Id} not found!");
            }
            else
            {
                tag.Id = request.Id;
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
                AddResult(tag);
            }
        }
    }
}
