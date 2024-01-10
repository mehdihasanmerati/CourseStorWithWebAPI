using CourseStor.Models.Comments.Commands;
using CourseStor.Models.Comments.Queries;
using CourseStor.Models.Frameworks;
using CourseStor.WebAPI.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseStor.WebAPI.CommentControllers
{
    public class CommentController : BaseController
    {
        public CommentController(IMediator mediator, ApplicationServiceResponse applicationService) : base(mediator, applicationService)
        {
        }

        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment(CreateComment comment) => await HandleResponse(comment);


        [HttpPut("UpdateComment")]
        public async Task<IActionResult> UpdateComment(UpdateComment comment) => await HandleResponse(comment);


        [HttpGet("SearchComment")]
        public async Task<IActionResult> SearchComment([FromQuery] FilteByComment comment) => await HandleResponse(comment);


        [HttpDelete("DeleteComment")]
        public async Task<IActionResult> DeleteComment(DeleteComment comment) => await HandleResponse(comment);


    }
}
