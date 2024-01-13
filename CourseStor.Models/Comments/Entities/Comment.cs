using CourseStor.Models.Courses.Entities;
using CourseStor.Models.Frameworks;

namespace CourseStor.Models.Comments.Entities
{
    public class Comment : BaseEntity
    {
        public string? Comments { get; set; }
        public string? CommentBy { get; set; }
        public int StarRate { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
