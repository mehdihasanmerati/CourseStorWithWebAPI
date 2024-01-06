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
    public class UpdateOrderCommandHandler : BaseApplicationServiceHandler<UpdateOrderCommand, Order>
    {
        public UpdateOrderCommandHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _context.Orders.SingleOrDefault(c=> c.Id == request.Id);
            if (order == null)
            {
                AddError($"The Course or Order with {request.Id} and {request.CourseId} is not exist or wrong! or other field is required.Try Again Please.");
            }
            else
            {
                order.Id = request.Id;
                order.CourseId = request.CourseId;
                order.Name = request.Name;
                order.Price = (double)request.Price;
                order.CustomerEmail = request.CustomerEmail;
                order.CreateOrder = (DateTime)request.CreateOrder;
                await _context.SaveChangesAsync();
                AddResult(order);
            }
        }
    }
}
