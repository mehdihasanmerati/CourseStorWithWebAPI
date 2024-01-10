using CourseStor.Models.Courses.Commands;
using CourseStor.Models.Courses.Queries;
using CourseStor.Models.Frameworks;
using CourseStor.WebAPI.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseStor.WebAPI.CourseControllers
{
    public class CourseController : BaseController
    {
        public CourseController(IMediator mediator, ApplicationServiceResponse applicationService) : base(mediator, applicationService)
        {
        }

        [HttpPost("CreateCourse")]
        public async Task<IActionResult> AddCourse(CreateCourse course) => await HandleResponse(course);


        [HttpPut("UpdateCourse")]
        public async Task<IActionResult> UpdateCourse(UpdateCourse course) => await HandleResponse(course);


        [HttpGet("SearchName")]
        public async Task<IActionResult> SearchName([FromQuery] FilterByInfo course) => await HandleResponse(course);


        [HttpDelete("DeleteCourse")]
        public async Task<IActionResult> DeleteCourse([FromQuery] DeleteCourse course) => await HandleResponse(course);
        

    }
}
