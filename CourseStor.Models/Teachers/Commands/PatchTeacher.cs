using CourseStor.Models.Frameworks;
using CourseStor.Models.Teachers.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CourseStor.Models.Teachers.Commands
{
    public class PatchTeacher : IRequest<ApplicationServiceResponse<Teacher>>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
