using Microsoft.AspNetCore.Mvc;
using PHShippingApp.Application.Services.Interfaces;

namespace PHShippingApp.API.Controllers
{
    [ApiController]
    [Route("api/shipping-services")]
    public class ShippingServiceController : ControllerBase
    {
        private readonly IShippingServiceService _service;

        public ShippingServiceController(IShippingServiceService service)
        {
            _service= service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }
    }
}
