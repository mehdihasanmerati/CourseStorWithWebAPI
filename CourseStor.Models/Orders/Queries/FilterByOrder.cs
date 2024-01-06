using CourseStor.Models.Frameworks;
using CourseStor.Models.Orders.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CourseStor.Models.Orders.Queries
{
    public class FilterByOrder: IRequest<ApplicationServiceResponse<List<OrderQueryResult>>>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? CustomerEmail { get; set; }
        public DateTime CreateOrder { get; set; }
    }
}
