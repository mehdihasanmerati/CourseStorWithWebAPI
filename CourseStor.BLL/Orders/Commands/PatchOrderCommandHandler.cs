using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Orders.Commands;
using CourseStor.Models.Orders.Entities;

namespace CourseStor.BLL.Orders.Commands
{
    public class PatchOrderCommandHandler : ApplicationServiceHandler<PatchOrderCommand, Order>
    {
        public PatchOrderCommandHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(PatchOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _context.Orders.SingleOrDefault(c => c.Id == request.Id);

            try
            {
                order.Id = request.Id;
                order.CourseId = request.CourseId;
                order.Name = request.Name;
                order.Price = request.Price;
                order.CustomerEmail = request.CustomerEmail;
                await _context.SaveChangesAsync();
                AddResult(order);

            }
            catch (Exception)
            {

                AddError($"The Course or Order with {request.Id} and {request.CourseId} is not exist or wrong! or other field is required.Try Again Please.");

            }
        }


    }
}
