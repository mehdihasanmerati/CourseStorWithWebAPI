using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Windows.Input;
using System.Linq;
using CourseStor.Models.Frameworks;
using CourseStor.BLL.Frameworks;

namespace CourseStor.WebAPI.Frameworks
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator mediator;
        public BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //protected async Task<IActionResult> HandleResponse<T>(T request)
        //{
        //    var response = await mediator.Send(request);
        //    return _responce.IsSuccess ? Ok(response) : BadRequest(_responce.Errors);
        //}

    }

}
