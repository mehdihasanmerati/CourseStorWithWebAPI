using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Comments.Dto
{
    public class CommentQueryResult
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public string CommentBy { get; set; }
        public int StarRate { get; set; }
    }
}
