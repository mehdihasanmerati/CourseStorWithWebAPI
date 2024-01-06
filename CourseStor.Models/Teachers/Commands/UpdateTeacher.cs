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
    public class UpdateTeacher: IRequest<ApplicationServiceResponse<Teacher>>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
