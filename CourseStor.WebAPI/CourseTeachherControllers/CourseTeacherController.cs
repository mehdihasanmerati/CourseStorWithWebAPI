using CourseStor.Models.Courses.CommandsTeacherCourse;
using CourseStor.Models.Courses.QueriesCourseTeacher;
using CourseStor.WebAPI.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseStor.WebAPI.CourseTeachherContorollers
{
    public class CourseTeacherController : BaseController
    {
        public CourseTeacherController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("CreateCourseTeacher")]
        public async Task<IActionResult> CreateCourseTeacher(CreateCourseTeacher courseTeacher)
        {
            var responce = await mediator.Send(courseTeacher);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

        [HttpPut("UpdateCourseTeacher")]
        public async Task<IActionResult> UpdateCourseTeacher(UpdateCourseTeacher courseTeacher)
        {
            var responce = await mediator.Send(courseTeacher);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

        [HttpGet("SearchCourseTeacher")]
        public async Task<IActionResult> SearchCourseTeacher([FromQuery]FilterByCourseTeacher courseTeacher)
        {
            var responce = await mediator.Send(courseTeacher);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

        [HttpDelete("DeleteCourseTeacher")]
        public async Task<IActionResult> DeleteCourseTeacher(DeleteCourseTeacher courseTeacher)
        {
            var responce = await mediator.Send(courseTeacher);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }
    }
}
