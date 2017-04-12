using AutoMapper;
using Moteling.API.ViewModels;
using Moteling.DATA.Entities;

namespace Moteling.API.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Motel
            CreateMap<Motel, MotelVM>();
            CreateMap<MotelVM, Motel>();

            //MotelAddress
            CreateMap<MotelAddress, MotelAddressVM>();
            CreateMap<MotelAddressVM, MotelAddress>();

            //MotelAddress
            CreateMap<Room, RoomVM>();
            CreateMap<RoomVM, Room>();

            //MotelAddress
            CreateMap<RoomImage, RoomImageVM>();
            CreateMap<RoomImageVM, RoomImage>();
        }
    }
}
