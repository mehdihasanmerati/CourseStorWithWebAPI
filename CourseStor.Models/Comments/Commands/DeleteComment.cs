using CourseStor.Models.Comments.Entities;
using CourseStor.Models.Frameworks;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Comments.Commands
{
    public class DeleteComment: IRequest<ApplicationServiceResponse<Comment>>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
