using CourseStor.Models.Courses.Commands;
using CourseStor.Models.Courses.Queries;
using CourseStor.WebAPI.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseStor.WebAPI.CourseControllers
{
    public class CourseController : BaseController
    {
        public CourseController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("CreateCourse")]
        public async Task<IActionResult> AddCourse(CreateCourse course)
        {
            var response = await mediator.Send(course);
            return response.IsSuccess ? Ok(response) : BadRequest(response.Errors);
        }

        [HttpPut("UpdateCourse")]
        public async Task<IActionResult> UpdateCourse(UpdateCourse course)
        {
            var responce = await mediator.Send(course);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

        [HttpGet("SearchName")]
        public async Task<IActionResult> SearchName([FromQuery] FilterByInfo course)
        {
            var responce = await mediator.Send(course);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

        [HttpDelete("DeleteCourse")]
        public async Task<IActionResult> DeleteCourse([FromQuery] DeleteCourse course)
        {
            var responce = await mediator.Send(course);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

    }
}
