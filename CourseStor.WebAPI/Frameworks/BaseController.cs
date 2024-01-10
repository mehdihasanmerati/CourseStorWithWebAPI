using CourseStor.BLL.Frameworks;
using CourseStor.Models.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseStor.WebAPI.Frameworks
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator mediator;
        private readonly ApplicationServiceResponse applicationService;

        public BaseController(IMediator mediator, ApplicationServiceResponse applicationService)
        {
            this.mediator = mediator;
            this.applicationService = applicationService;
        }

        protected async Task<IActionResult> HandleResponse<T>(T request)
        {
            var response = await mediator.Send(request);
            return applicationService.IsSuccess ? Ok(response) : BadRequest(applicationService.Errors);
            
        }

    }

}
