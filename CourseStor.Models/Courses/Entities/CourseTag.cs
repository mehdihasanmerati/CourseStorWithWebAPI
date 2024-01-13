using CourseStor.Models.Frameworks;
using CourseStor.Models.Tags.Entities;

namespace CourseStor.Models.Courses.Entities
{
    public class CourseTag: BaseEntity
    {
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
