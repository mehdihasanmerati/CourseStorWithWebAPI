using CourseStor.Models.Comments.Entities;
using CourseStor.Models.Frameworks;
using CourseStor.Models.Orders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Courses.Entities
{
    public class Course: BaseEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public double Price { get; set; }
        public DateTime CreateDateCorse { get; set; }
        public List<CourseTeacher> CourseTeachers{get; set; }
        public List<CourseTag> CourseTags { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Order> OrderCourses { get; set; }
    }
}
