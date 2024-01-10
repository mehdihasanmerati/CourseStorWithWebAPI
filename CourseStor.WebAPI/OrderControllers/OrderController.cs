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
        public OrderController(IMediator mediator, ApplicationServiceResponse responceForUI) : base(mediator, responceForUI)
        {
        }


        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand order) => await HandleResponse(order);


        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand order) => await HandleResponse(order);


        [HttpGet("SearchOrder")]
        public async Task<IActionResult> SearchOrder([FromQuery] FilterByOrder order) => await HandleResponse(order);



        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder([FromQuery] DeleteOrderCommand order) => await HandleResponse(order);


    }
}



    


