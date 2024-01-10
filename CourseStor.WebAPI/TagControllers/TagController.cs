using CourseStor.Models.Frameworks;
using CourseStor.Models.Tags.Commands;
using CourseStor.Models.Tags.Quries;
using CourseStor.WebAPI.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseStor.WebAPI.TagControllers
{

    public class TagController : BaseController
    {
        public TagController(IMediator mediator, ApplicationServiceResponse applicationService) : base(mediator, applicationService)
        {
        }

        [HttpPost("CreateTag")]
        public async Task<IActionResult> CreateTag(CreateTag tag) => await HandleResponse(tag);


        [HttpPut("UpdateTag")]
        public async Task<IActionResult> UpdateTag(UpdateTag tag) => await HandleResponse(tag);


        [HttpGet("SearchByName")]
        public async Task<IActionResult> SearchByName([FromQuery] FilterByName tag) => await HandleResponse(tag);


        [HttpDelete("DeleteByName")]
        public async Task<IActionResult> DeleteByName([FromQuery] DeleteTag tag) => await HandleResponse(tag);
        
    }
}
