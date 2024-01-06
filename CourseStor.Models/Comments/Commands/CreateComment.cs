using CourseStor.Models.Comments.Entities;
using CourseStor.Models.Frameworks;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Comments.Commands
{
    public class CreateComment: IRequest<ApplicationServiceResponse<Comment>>
    {
        [StringLength(100, MinimumLength = 5)]
        public string Comments { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string CommentBy { get; set; }
        public int StarRate { get; set; }

        [DisplayName("Course Id Related")]
        public int CourseId { get; set; }
    }
}
