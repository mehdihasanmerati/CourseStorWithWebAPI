using CourseStor.Models.Frameworks;
using CourseStor.Models.Teachers.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Teachers.Commands
{
    public class CreateTeacher: IRequest<ApplicationServiceResponse<Teacher>>
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
    }
}
