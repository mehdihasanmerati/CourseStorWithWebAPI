using CourseStor.Models.Frameworks;
using CourseStor.Models.Tags.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CourseStor.Models.Tags.Commands
{
    public class UpdateTag: IRequest<ApplicationServiceResponse<Tag>>
    {
        [Required]
        [Range(1,int.MaxValue)]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string TagName { get; set; }
    }
}
