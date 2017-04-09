using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Moteling.API.Controllers
{
    [Route("api/[controller]")]
    public class MotelController : Controller
    {
        private readonly ILogger<MotelController> _logger;

        public MotelController(ILogger<MotelController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("Get Method");
            return new string[] { "value1", "value2" };
        }
    }
}
