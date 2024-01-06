using CourseStor.Models.Frameworks;
using CourseStor.Models.Orders.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CourseStor.Models.Orders.Commands
{
    public class UpdateOrderCommand: IRequest<ApplicationServiceResponse<Order>>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int CourseId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        public double? Price { get; set; }
        [EmailAddress]
        public string? CustomerEmail { get; set; }
        public DateTime? CreateOrder { get; set; }
    }
}
