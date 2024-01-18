using Azure;
using CourseStor.Models.Comments.Commands;
using CourseStor.Models.Comments.Queries;
using CourseStor.Models.Frameworks;
using CourseStor.WebAPI.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

        [HttpPatch("PatchComment")]
        public async Task<IActionResult> PatchComment(int id,int courseId,JsonPatchDocument<PatchComment> jsonDocument)
        {
            var comments = new PatchComment();
            try
            {
                if (jsonDocument != null && ModelState.IsValid)
                {
                    comments.Id = id;
                    comments.CourseId = courseId;
                    jsonDocument.ApplyTo(comments);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return await HandleResponse(comments);
        }

    }
}
