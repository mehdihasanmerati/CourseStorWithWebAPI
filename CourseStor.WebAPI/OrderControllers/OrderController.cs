using CourseStor.Models.Orders.Commands;
using CourseStor.Models.Orders.Queries;
using CourseStor.WebAPI.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CourseStor.Models.Frameworks;
using Microsoft.AspNetCore.JsonPatch;

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
        public async Task<IActionResult> DeleteOrder(DeleteOrderCommand order) => await HandleResponse(order);

        [HttpPatch("PatchOrder")]
        public async Task<IActionResult> PatchOrder(int id,int courseId, JsonPatchDocument<PatchOrderCommand> jsonDocument)
        {
            var patchOrder = new PatchOrderCommand();
            if (jsonDocument != null && ModelState.IsValid)
            {
                patchOrder.Id = id;
                patchOrder.CourseId = courseId;
                jsonDocument.ApplyTo(patchOrder);
            }
            return await HandleResponse(patchOrder);
        }
    }
}



    


