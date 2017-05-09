using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moteling.API.ViewModels;
using Moteling.DATA.Entities;
using Moteling.DATA.Extensions;
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
        private IEntityService<Room> _roomService;

        public MotelController(ILogger<MotelController> logger,
            IMapper mapper,
            IEntityService<Motel> motelService,
            IEntityService<Room> roomService)
        {
            _logger = logger;
            _mapper = mapper;
            _motelService = motelService;
            _roomService = roomService;
        }

        [HttpGet]
        public JsonResult Get(string country = "COLOMBIA", string city = "BARRANQUILLA")
        {
            _logger.LogInformation("Get Method");

            List<Motel> result = _motelService.FindByAndInclude(
                m => m.Address.Country == country && m.Address.City == city, 
                m => m.Address).ToList();

            foreach(var motel in result)
            {
                motel.Rooms = _roomService.FindByAndInclude(
                    room => room.MotelId == motel.Id, 
                    room => room.Images).ToList();
            }
            
            List<MotelVM> motels = _mapper.Map<List<MotelVM>>(result);

            return Json(motels);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            _logger.LogInformation("Get Motel id={0}", id);

            Motel result = _motelService.FindByAndInclude(
                m => m.Id == id,
                m => m.Address).FirstOrDefault();

            if(result == null)
            {
                return null;
            }

            result.Rooms = _roomService.FindByAndInclude(room => room.MotelId == id, room => room.Images).ToList();
            MotelVM motel = _mapper.Map<MotelVM>(result);

            return Json(motel);
        }
    }
}
