using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Moteling.API.Controllers
{
    [Route("api/[controller]")]
    public class MotelController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
