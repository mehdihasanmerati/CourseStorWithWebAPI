using CourseStor.Models.Courses.Entities;
using CourseStor.Models.Frameworks;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CourseStor.Models.Courses.Commands
{
    public class PatchCourse : IRequest<ApplicationServiceResponse<Course>>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public double? Price { get; set; }
        public DateTime? CreateDateCorse { get; set; }
    }
}
