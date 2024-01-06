using CourseStor.Models.Courses.Dto;
using CourseStor.Models.Frameworks;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Courses.Queries
{
    public class FilterByInfo: IRequest<ApplicationServiceResponse<List<CourseQueryResult>>>
    {
        [Required]
        [Range(1,int.MaxValue)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public double? Price { get; set; }
        public DateTime? CreateDateCorse { get; set; }
    }
}
