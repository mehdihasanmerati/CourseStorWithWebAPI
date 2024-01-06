using CourseStor.Models.Frameworks;
using CourseStor.Models.Teachers.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.Models.Teachers.Queries
{
    public class FilterByTeacher: IRequest<ApplicationServiceResponse<List<TeacherQueryResult>>>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
