using CourseStor.Models.Courses.CommandsTeacherCourse;
using CourseStor.Models.Courses.QueriesCourseTeacher;
using CourseStor.Models.Frameworks;
using CourseStor.WebAPI.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseStor.WebAPI.CourseTeachherContorollers
{
    public class CourseTeacherController : BaseController
    {
        public CourseTeacherController(IMediator mediator, ApplicationServiceResponse applicationService) : base(mediator, applicationService)
        {
        }

        [HttpPost("CreateCourseTeacher")]
        public async Task<IActionResult> CreateCourseTeacher(CreateCourseTeacher courseTeacher) => await HandleResponse(courseTeacher);

        [HttpPut("UpdateCourseTeacher")]
        public async Task<IActionResult> UpdateCourseTeacher(UpdateCourseTeacher courseTeacher) => await HandleResponse(courseTeacher);

        [HttpGet("SearchCourseTeacher")]
        public async Task<IActionResult> SearchCourseTeacher([FromQuery] FilterByCourseTeacher courseTeacher) => await HandleResponse(courseTeacher);

        [HttpDelete("DeleteCourseTeacher")]
        public async Task<IActionResult> DeleteCourseTeacher(DeleteCourseTeacher courseTeacher) => await HandleResponse(courseTeacher);
        

    }
}
