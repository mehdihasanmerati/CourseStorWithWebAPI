using CourseStor.Models.Courses.Entities;
using CourseStor.Models.Frameworks;

namespace CourseStor.Models.Tags.Entities
{
    public class Tag : BaseEntity
    {
        public string TagName { get; set; }
        public List<CourseTag> CourseTags { get; set; }
    }
}
