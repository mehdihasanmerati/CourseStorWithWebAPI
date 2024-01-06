using CourseStor.Models.Courses.Entities;
using CourseStor.Models.Frameworks;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Courses.Commands
{
    public class UpdateCourse: IRequest<ApplicationServiceResponse<Course>>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }
        public string? ShortDescription { get; set; }
        public double? Price { get; set; }
        public DateTime? CreateDateCorse { get; set; }
    }
}
