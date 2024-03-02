using CourseStor.Models.Courses.CommandsCourseTeacher;
using CourseStor.Models.Courses.CommandsTeacherCourse;
using CourseStor.Models.Courses.QueriesCourseTeacher;
using CourseStor.Models.Frameworks;
using CourseStor.WebAPI.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CourseStor.WebAPI.CourseTeachherControllers
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

        [HttpPatch("PatchCourseTeacher")]
        public async Task<IActionResult> PatchCourseTeacher(int id, int courseid, int teacherid, JsonPatchDocument<PatchCourseTeacher> jsonPatch)
        {
            var courseTeacher = new PatchCourseTeacher();
            try
            {
                if (jsonPatch != null && ModelState.IsValid)
                {
                    courseTeacher.Id = id;
                    courseTeacher.CourseId = courseid;
                    courseTeacher.TeacherId = teacherid;
                    jsonPatch.ApplyTo(courseTeacher);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return await HandleResponse(courseTeacher);
        }

    }
}
