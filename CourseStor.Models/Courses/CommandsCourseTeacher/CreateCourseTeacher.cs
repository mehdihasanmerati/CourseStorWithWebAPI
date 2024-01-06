using CourseStor.Models.Courses.Entities;
using CourseStor.Models.Frameworks;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Courses.CommandsTeacherCourse
{
    public class CreateCourseTeacher: IRequest<ApplicationServiceResponse<CourseTeacher>>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int SortOrder { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int TeacherId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int CourseId {  get; set; }
    }
}
