using CourseStor.Models.Comments.Commands;
using CourseStor.Models.Comments.Queries;
using CourseStor.WebAPI.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseStor.WebAPI.CommentControllers
{
    public class CommentController : BaseController
    {
        public CommentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment(CreateComment comment)
        {
            var responce = await mediator.Send(comment);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

        [HttpPut("UpdateComment")]
        public async Task<IActionResult> UpdateComment(UpdateComment comment)
        {
            var responce = await mediator.Send(comment);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

        [HttpGet("SearchComment")]
        public async Task<IActionResult> SearchComment([FromQuery] FilteByComment comment)
        {
            var responce = await mediator.Send(comment);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

        [HttpDelete("DeleteComment")]
        public async Task<IActionResult> DeleteComment(DeleteComment comment)
        {
            var responce = await mediator.Send(comment);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }
    }
}
