using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moteling.DATA.Entities;
using Moteling.DATA.Infrastructure;
using Moteling.DATA.Services.Interfaces;
using Moteling.WEB.ViewModels.Motel;
using System.Linq;

namespace Moteling.WEB.Controllers
{

    public class MotelController : Controller
    {
        //private readonly IMapper _mapper;
        private readonly IEntityService<Motel> _motelService;
        private readonly IEntityService<MotelAddress> _motelAddressService;
        private readonly IContextBase _context;

        public MotelController(IEntityService<Motel> motelService,
            IEntityService<MotelAddress> motelAddressService,
            IContextBase context)
        {
            _motelService = motelService;
            _motelAddressService = motelAddressService;
            _context = context;
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


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateMotelViewModel motelVM)
        {
            if(ModelState.IsValid)
            {
                Motel motel = new Motel()
                {
                    Description = motelVM.Description,
                    Name = motelVM.Name,
                    Page = motelVM.Page,
                    PhoneNumber = motelVM.PhoneNumber
                };

                _motelService.Add(motel);
                _context.Commit();

                MotelAddress address = new MotelAddress()
                {
                    Address = motelVM.Address,
                    City = "BARRANQUILLA",
                    Country = "COLOMBIA",
                    Latitude = 10.4525,
                    Longitude = 35.254,
                    Id = motel.Id
                };
                _motelAddressService.Add(address);
                _context.Commit();
            }
            
            return View(motelVM);
        }
    }
}
