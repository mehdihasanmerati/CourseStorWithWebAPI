using CourseStor.Models.Frameworks;
using CourseStor.Models.Orders.Entities;
using CourseStor.Models.Tags.Entities;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Orders.Commands
{
    public class PatchOrderCommand: IRequest<ApplicationServiceResponse<Order>>
    {
        [ForeignKey(nameof(CourseId))]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Range(1, int.MaxValue)]
        public int CourseId { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string? Name { get; set; }
        public double Price { get; set; }
        [EmailAddress]
        public string? CustomerEmail { get; set; }
    }
}
