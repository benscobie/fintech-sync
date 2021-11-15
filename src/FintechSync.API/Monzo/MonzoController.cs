using FintechSync.API.Monzo;
using Microsoft.AspNetCore.Mvc;

namespace FintechSync.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonzoController : ControllerBase
    {

        private readonly ILogger<MonzoController> _logger;

        public MonzoController(ILogger<MonzoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Webhook(MonzoEventDto @event)
        {
            return Ok();
        }
    }
}