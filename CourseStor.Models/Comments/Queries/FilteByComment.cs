using CourseStor.Models.Comments.Dto;
using CourseStor.Models.Frameworks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Comments.Queries
{
    public class FilteByComment: IRequest<ApplicationServiceResponse<List<CommentQueryResult>>>
    {
        public int Id { get; set; }
        public string? Comments { get; set; }
        public string? CommentBy { get; set; }
        public int StarRate { get; set; }

    }
}
