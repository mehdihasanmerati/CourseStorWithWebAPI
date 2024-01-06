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
        public TeacherController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("CreateTeacher")]
        public async Task<IActionResult> CreateTeacher(CreateTeacher teacher)
        {
            var responce = await mediator.Send(teacher);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

        [HttpPut("UpdateTeacher")]
        public async Task<IActionResult> UpdateTeacher(UpdateTeacher teacher)
        {
            var responce = await mediator.Send(teacher);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

        [HttpGet("SearchInfo")]
        public async Task<IActionResult> SearchInfo([FromQuery] FilterByTeacher teacher)
        {
            var responce = await mediator.Send(teacher);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }



        [HttpDelete("DeleteTeacher")]
        public async Task<IActionResult> DeleteTeacher(DeleteTeacher teacher)
        {
            var responce = await mediator.Send(teacher);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }
    }
}
