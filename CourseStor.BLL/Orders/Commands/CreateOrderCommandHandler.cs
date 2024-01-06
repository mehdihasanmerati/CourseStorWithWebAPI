using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.Models.Orders.Commands;
using CourseStor.Models.Orders.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.BLL.Orders.Commands
{
    public class CreateOrderCommandHandler : BaseApplicationServiceHandler<CreateOrderCommand, Order>
    {

        public CreateOrderCommandHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = new Order()
            {
                CourseId = request.CourseId,
                Name = request.Name,
                Price = (double)request.Price,
                CustomerEmail = request.CustomerEmail,
                CreateOrder = (DateTime)request.CreateOrder,
            };

            try
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                AddResult(order);

            }
            catch (Exception)
            {
                AddError($"The CourseId {request.CourseId} is not exist or wrong! Try Again");
            }

        }
    }
}
