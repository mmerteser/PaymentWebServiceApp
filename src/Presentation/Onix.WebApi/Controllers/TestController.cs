using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onix.Application.Abstractions.Services.IntegratedApplicationServices;
using Onix.Integration.PaymentServices.Paynet;

namespace Onix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IPaynetService _paynetService;
        public TestController(IPaynetService paynetService)
        {
            _paynetService = paynetService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _paynetService.InitializeSaleTransactionAsync());
        }
    }
}
