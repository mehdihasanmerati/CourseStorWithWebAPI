using CourseStor.Models.Tags.Commands;
using CourseStor.Models.Tags.Quries;
using CourseStor.WebAPI.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseStor.WebAPI.TagControllers
{

    public class TagController : BaseController
    {
        public TagController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("CreateTag")]
        public async Task<IActionResult> CreateTag(CreateTag tag)
        {
            var response = await mediator.Send(tag);
            //if (response.IsSuccess)
            //{
            //    return Ok(response);
            //}

            return response.IsSuccess ? Ok(response) : BadRequest(response.Errors);
        }

        [HttpPut("UpdateTag")]
        public async Task<IActionResult> UpdateTag(UpdateTag tag)
        {
            var responce = await mediator.Send(tag);

            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

        [HttpGet("SearchByName")]
        public async Task<IActionResult> SearchByName([FromQuery] FilterByName tag)
        {
            var responce = await mediator.Send(tag);

            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

        [HttpDelete("DeleteByName")]
        public async Task<IActionResult> DeleteByName([FromQuery] DeleteTag tag)
        {
            var responce = await mediator.Send(tag);

            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }
    }
}
