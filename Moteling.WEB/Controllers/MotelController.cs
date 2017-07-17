using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moteling.DATA.Entities;
using Moteling.DATA.Infrastructure;
using Moteling.DATA.Services.Interfaces;

namespace Moteling.WEB.Controllers
{
    public class MotelController : Controller
    {
        private readonly ILogger<MotelController> _logger;
        private IEntityService<Motel> _motelService;
        private IContextBase _context;

        public MotelController(ILogger<MotelController> logger, 
            IEntityService<Motel> motelService,
            IContextBase context)
        {
            _logger = logger;
            _motelService = motelService;
            _context = context;
        }

        public IActionResult Index()
        {
            var motels = _motelService.GetAll();
            return View();
        }
    }
}
