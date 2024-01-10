using Azure.Core;
using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Frameworks;
using CourseStor.Models.Tags.Commands;
using CourseStor.Models.Tags.Entities;
using MediatR;

namespace CourseStor.BLL.Tags.Commands
{
    public class CreateTagHandler : ApplicationServiceHandler<CreateTag,Tag>
    {
        public CreateTagHandler(CourseStorDbContext _context) : base(_context)
        {
        }

        protected override async Task HandleRequest(CreateTag request, CancellationToken cancellationToken)
        {
            Tag tag = new()
            {
                TagName = request.TagName
            };
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            
            AddResult(tag);
        }
    }
}
