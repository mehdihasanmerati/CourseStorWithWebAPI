using CourseStor.Models.Courses.Entities;
using CourseStor.Models.Frameworks;
using CourseStor.Models.Teachers.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Courses.QueriesCourseTeacher
{
    public class FilterByCourseTeacher: IRequest<ApplicationServiceResponse<List<CourseTeacher>>>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        public int SortOrder { get; set; }
    }
}
