using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moteling.API.ViewModels;
using Moteling.DATA.Entities;
using Moteling.DATA.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Moteling.API.Controllers
{
    [Route("api/[controller]")]
    public class MotelController : Controller
    {
        private readonly ILogger<MotelController> _logger;
        private readonly IMapper _mapper;
        private IEntityService<Motel> _motelService;
        private IEntityService<RoomImage> _roomImageService;

        public MotelController(ILogger<MotelController> logger,
            IMapper mapper,
            IEntityService<Motel> motelService,
            IEntityService<RoomImage> roomImageService)
        {
            _logger = logger;
            _mapper = mapper;
            _motelService = motelService;
            _roomImageService = roomImageService;
        }

        [HttpGet]
        public JsonResult Get()
        {
            _logger.LogInformation("Get Method");

            List<Motel> result = _motelService.FindByAndInclude(m => m.Id > 0, m => m.Rooms, m => m.Address).ToList();
            List<MotelVM> motels = _mapper.Map<List<MotelVM>>(result);

            return Json(motels);
        }
    }
}
