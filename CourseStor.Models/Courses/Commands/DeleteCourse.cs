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
    public class DeleteCourse: IRequest<ApplicationServiceResponse<Course>>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
