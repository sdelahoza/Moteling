using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moteling.DATA.Entities;
using Moteling.DATA.Services.Interfaces;
using System.Linq;

namespace Moteling.WEB.Controllers
{
    [Authorize]
    public class MotelController : Controller
    {
        //private readonly IMapper _mapper;
        private readonly IEntityService<Motel> _motelService;

        public MotelController(IEntityService<Motel> motelService)
        {
            _motelService = motelService;
            //_mapper = mapper;
        }

        [AllowAnonymous]
        public IActionResult Index(string country = "COLOMBIA", string city = "BARRANQUILLA")
        {
            var result = _motelService.FindByAndInclude(
                m => m.Address.Country == country && m.Address.City == city,
                m => m.Address);
            return View(result);
        }
    }
}
