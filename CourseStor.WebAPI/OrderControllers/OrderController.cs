using CourseStor.Models.Orders.Commands;
using CourseStor.Models.Orders.Queries;
using CourseStor.WebAPI.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Windows.Input;
using CourseStor.Models.Frameworks;

namespace CourseStor.WebAPI.Orders
{
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand order)
        {
            var responce = await mediator.Send(order);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

        //[HttpPost("CreateOrder")]
        //public async Task<IActionResult> CreateOrder(CreateOrderCommand order) => await HandleResponse(order);


        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand order)
        {
            var responce = await mediator.Send(order);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

        [HttpGet("SearchOrder")]
        public async Task<IActionResult> SearchOrder([FromQuery] FilterByOrder order)
        {
            var responce = await mediator.Send(order);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }


        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder([FromQuery] DeleteOrderCommand order)
        {
            var responce = await mediator.Send(order);
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce.Errors);
        }

    }



    

}
