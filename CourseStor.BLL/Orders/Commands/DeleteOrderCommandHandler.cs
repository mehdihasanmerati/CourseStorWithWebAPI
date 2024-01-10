using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Orders.Commands;
using CourseStor.Models.Orders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Orders.Commands
{
    public class DeleteOrderCommandHandler : ApplicationServiceHandler<DeleteOrderCommand, Order>
    {
        public DeleteOrderCommandHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _context.Orders.SingleOrDefault(c => c.Id == request.Id);
            if (order == null)
            {
                AddError($"The Order with Id {request.Id} is not exist!");
            }
            else
            {
                order.Id = request.Id;
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();

                AddResult(order);
            }
        }
    }
}
