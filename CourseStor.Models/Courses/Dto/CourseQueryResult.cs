using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Courses.Dto
{
    public class CourseQueryResult
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public double? Price { get; set; }
        public DateTime? CreateDateCorse { get; set; }
    }
}
