using CourseStor.Models.Frameworks;
using CourseStor.Models.Teachers.Commands;
using CourseStor.Models.Teachers.Queries;
using CourseStor.WebAPI.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseStor.WebAPI.TeacherControllers
{

    public class TeacherController : BaseController
    {
        public TeacherController(IMediator mediator, ApplicationServiceResponse applicationService) : base(mediator, applicationService)
        {
        }

        [HttpPost("CreateTeacher")]
        public async Task<IActionResult> CreateTeacher(CreateTeacher teacher) => await HandleResponse(teacher);


        [HttpPut("UpdateTeacher")]
        public async Task<IActionResult> UpdateTeacher(UpdateTeacher teacher) => await HandleResponse(teacher);

        [HttpGet("SearchInfo")]
        public async Task<IActionResult> SearchInfo([FromQuery] FilterByTeacher teacher) => await HandleResponse(teacher);

        [HttpDelete("DeleteTeacher")]
        public async Task<IActionResult> DeleteTeacher(DeleteTeacher teacher) => await HandleResponse(teacher);
        
    }
}
