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
                if (order != null)
                {
                    order.CourseId = request.CourseId;
                    order.Name = request.Name;
                    order.Price = request.Price;
                    order.CustomerEmail = request.CustomerEmail;
                    await _context.SaveChangesAsync();
                    AddResult(order);
                }
                else
                {
                    AddError($"The Course or Order with {request.Id} and {request.CourseId} does not exist or is wrong! or other field is required. Try again please.");
                }
            }
            catch (Exception)
            {
                AddError($"An error occurred while updating the order. Please try again.");
            }

        }


    }
}
