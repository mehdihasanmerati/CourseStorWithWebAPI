using CourseStor.Models.Courses.Entities;
using CourseStor.Models.Frameworks;

namespace CourseStor.Models.Orders.Entities
{
    public class Order : BaseEntity
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CreateOrder { get; set; }
    }
}
