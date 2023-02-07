using Microsoft.AspNetCore.Mvc;
using PHShippingApp.Application.InputModels;
using PHShippingApp.Application.Services.Interfaces;
using System.Reflection;

namespace PHShippingApp.API.Controllers
{
    [ApiController]
    [Route("/api/shipping-orders")]
    public class ShippingOrderController : ControllerBase
    {
        private readonly IShippingOrderService _service;

        public ShippingOrderController(IShippingOrderService service)
        {
            _service = service;
        }

        [HttpGet("{trackingCode}")]
        public async Task<IActionResult> GetByTrackingCode(string trackingCode)
        {
            var shippingOrder = await _service.GetByCode(trackingCode);

            if(shippingOrder == null)
                return NotFound();

            return Ok(shippingOrder);
        }

        [HttpPost]
        public async Task<IActionResult> AddShippingOrder(AddShippingOrderInputModel addShippingOrderInputModel)
        {
            var code = await _service.Add(addShippingOrderInputModel);

            if(string.IsNullOrEmpty(code))
                return BadRequest();

            return Ok();
        }
    }
}
