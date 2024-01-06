using CourseStor.Models.Frameworks;
using CourseStor.Models.Tags.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Tags.Commands
{
    public class CreateTag: IRequest<ApplicationServiceResponse<Tag>>
    {
        [Required]
        [StringLength(50,MinimumLength = 2)]
        public string TagName { get; set; }
    }
}
