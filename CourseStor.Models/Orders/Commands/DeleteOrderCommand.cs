using CourseStor.Models.Frameworks;
using CourseStor.Models.Orders.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Orders.Commands
{
    public class DeleteOrderCommand: IRequest<ApplicationServiceResponse<Order>>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
