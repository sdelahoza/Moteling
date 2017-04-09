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
        private IEntityService<Motel> _motelService;
        private IEntityService<RoomImage> _roomImageService;

        public MotelController(ILogger<MotelController> logger, 
            IEntityService<Motel> motelService,
            IEntityService<RoomImage> roomImageService)
        {
            _logger = logger;
            _motelService = motelService;
            _roomImageService = roomImageService;
        }

        [HttpGet]
        public JsonResult Get()
        {
            _logger.LogInformation("Get Method");

            List<MotelVM> motelsVM = new List<MotelVM>();
            List<MotelAddressVM> addressVM = new List<MotelAddressVM>();
            List<RoomVM> roomVM = new List<RoomVM>();

            var result = _motelService.FindByAndInclude(m => m.Id > 0, m => m.Rooms, m => m.Address);
            foreach (var r in result)
            {
                var addressT = new MotelAddressVM()
                {
                    Address = r.Address.Address,
                    City = r.Address.City,
                    Country = r.Address.Country,
                    Latitude = r.Address.Latitude,
                    Longitude = r.Address.Longitude,
                    MotelAddressId = r.Address.Id
                };

                var roomListT = new List<RoomVM>();
                foreach (var ro in r.Rooms)
                {
                    List<RoomImageVM> roomImageVM = new List<RoomImageVM>();
                    var imagenes = _roomImageService.FindBy(x => x.RoomId == ro.Id);
                    foreach(var i in imagenes)
                    {
                        roomImageVM.Add(
                            new RoomImageVM { ImageUrl = i.ImageUrl, RoomId = i.RoomId, RoomImageId = i.Id });
                    }
                    roomListT.Add(
                        new RoomVM { MotelId = r.Id, Name = ro.Name, RoomId = ro.Id, Images = roomImageVM });
                }

                motelsVM.Add(
                    new MotelVM { Address = addressT, Description = r.Description, MotelId = r.Id, Name = r.Name, Page = r.Page, PhoneNumber = r.PhoneNumber, Rooms = roomListT });
            }

            return Json(motelsVM);
        }
    }
}
