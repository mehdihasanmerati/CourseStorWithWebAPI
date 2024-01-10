using CourseStor.BLL.Frameworks;
using CourseStor.DAL.DbContexts;
using CourseStor.DAL.Frameworks;
using CourseStor.Models.Orders.Dto;
using CourseStor.Models.Orders.Queries;

namespace CourseStor.BLL.Orders.Queries
{
    public class FilterByOrderHandler : ApplicationServiceHandler<FilterByOrder, List<OrderQueryResult>>
    {
        public FilterByOrderHandler(CourseStorDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(FilterByOrder request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.WhereOverOrder(request.Id).ToOrderQueryAsync();
            AddResult(order);
        }
    }
}
