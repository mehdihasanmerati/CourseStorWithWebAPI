using CourseStor.Models.Frameworks;
using CourseStor.Models.Tags.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CourseStor.Models.Tags.Commands
{
    public class PatchForTag: IRequest<ApplicationServiceResponse<Tag>>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string TagName { get; set; }

    }
}
