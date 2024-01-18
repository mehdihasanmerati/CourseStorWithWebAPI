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
    public class PatchComment : IRequest<ApplicationServiceResponse<Comment>>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string Comments { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string CommentBy { get; set; }
        public int StarRate { get; set; }
        public int CourseId { get; set; }
    }
}
