using Moteling.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moteling.DATA
{
    public class DbInitializer
    {
        public static void Initialize(MotelingContext context)
        {
            // If db doesn't exist is created
            context.Database.EnsureCreated();

            // Look for any motel
            if (context.Motels.Any())
                return;     // DB has been seeded

            var motels = new Motel[]
            {
                new Motel{Name="Carpe Diem", PhoneNumber="5555555 - 9999999999", Description="Motel 1", Page="https://www.motelcarpediem.com/barrioabajo.html"},
                new Motel{Name="El Faro", PhoneNumber="5555555 - 9999999999", Description="Motel 2"},
                new Motel{Name="Amoblados Casanova V.I.P.", PhoneNumber="5555555 - 9999999999", Description="Motel 3"},
                new Motel{Name="Deseos", PhoneNumber="5555555 - 9999999999", Description="Motel 4"},
                new Motel{Name="Ibiza", PhoneNumber="5555555 - 9999999999", Description="Motel 5"},
                new Motel{Name="Hotel Astor", PhoneNumber="5555555 - 9999999999", Description="Motel 6"}
            };

            //Add objects
            foreach (Motel m in motels)
            {
                context.Motels.Add(m);
            }

            //Commit changes
            //context.SaveChanges();

            var addresses = new MotelAddress[]
            {
                new MotelAddress{Id=1, Address="Calle 68 # 60 - 86", Latitude=10.999970, Longitude=-74.794251, City="BARRANQUILLA", Country="COLOMBIA"},
                new MotelAddress{Id=2, Address="Calle 70 # 60 - 86", Latitude=11.001578, Longitude=-74.795444, City="BARRANQUILLA", Country="COLOMBIA"},
                new MotelAddress{Id=3, Address="Calle 72 # 60 - 86", Latitude=11.002762, Longitude=-74.796331, City="BARRANQUILLA", Country="COLOMBIA"},
                new MotelAddress{Id=4, Address="Calle 74 # 60 - 86", Latitude=11.003983, Longitude=-74.797217, City="BARRANQUILLA", Country="COLOMBIA"},
                new MotelAddress{Id=5, Address="Calle 72 # 54 - 86", Latitude=10.999390, Longitude=-74.801016, City="BARRANQUILLA", Country="COLOMBIA"},
                new MotelAddress{Id=6, Address="Calle 72 # 48 - 86", Latitude=10.996438, Longitude=-74.804409, City="BARRANQUILLA", Country="COLOMBIA"}
            };

            foreach (MotelAddress a in addresses)
            {
                context.Addresses.Add(a);
            }

            var rooms = new Room[]
            {
                new Room{MotelId=1, Name="Cabaña Ejecutiva"},
                new Room{MotelId=1, Name="Cabaña Suite"},
                new Room{MotelId=1, Name="Suite Presidencial"},
                new Room{MotelId=2, Name="Cabaña Ejecutiva"},
                new Room{MotelId=2, Name="Cabaña Suite"},
                new Room{MotelId=3, Name="Suite Presidencial"},
                new Room{MotelId=4, Name="Cabaña Ejecutiva"},
                new Room{MotelId=4, Name="Cabaña Suite"},
                new Room{MotelId=4, Name="Suite Presidencial"},
                new Room{MotelId=5, Name="Cabaña Ejecutiva"},
                new Room{MotelId=6, Name="Cabaña Suite"},
                new Room{MotelId=6, Name="Suite Presidencial"},
            };

            foreach(Room r in rooms)
            {
                context.Rooms.Add(r);
            }

            var roomImages = new RoomImage[]
            {
                new RoomImage{ImageUrl="https://www.motelcarpediem.com/images/galeria1.jpg", RoomId=1},
                new RoomImage{ImageUrl="https://www.motelcarpediem.com/images/galeria9.jpg", RoomId=2},
                new RoomImage{ImageUrl="https://www.motelcarpediem.com/images/galeria4.jpg", RoomId=2},
                new RoomImage{ImageUrl="https://www.motelcarpediem.com/images/galeria10.jpg", RoomId=3},
                new RoomImage{ImageUrl="https://www.motelcarpediem.com/images/galeria12.jpg", RoomId=3},
                new RoomImage{ImageUrl="https://www.motelcarpediem.com/images/galeria13.jpg", RoomId=3},
            };

            foreach(RoomImage ri in roomImages)
            {
                context.RoomImages.Add(ri);
            }

            context.SaveChanges();
        }
    }
}
