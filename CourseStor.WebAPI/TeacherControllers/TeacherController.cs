using CourseStor.Models.Frameworks;
using CourseStor.Models.Teachers.Commands;
using CourseStor.Models.Teachers.Queries;
using CourseStor.WebAPI.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPatch("PatchTeacher")]
        public async Task<IActionResult> PatchTeacher(int id,JsonPatchDocument<PatchTeacher> jsonPatchTeacher)
        {
            var teachers = new PatchTeacher();
            try
            { 
                if (jsonPatchTeacher != null)
                {
                    teachers.Id = id;
                    jsonPatchTeacher.ApplyTo(teachers);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return await HandleResponse(teachers);
        } 
        
        
        
    }
}
