using Microsoft.EntityFrameworkCore;
using Moteling.DATA.Configurations;
using Moteling.DATA.Entities;
using Moteling.DATA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moteling.DATA
{
    public class MotelingContext : DbContext, IContextBase
    {
        //Variables only to Initialze db
        public DbSet<Motel> Motels { get; set; }
        public DbSet<MotelAddress> Addresses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }

        public MotelingContext(DbContextOptions<MotelingContext> options) : base(options)
        {

        }

        public int Commit()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new RoomImageConfiguration());
            modelBuilder.AddConfiguration(new RoomConfiguration());
            modelBuilder.AddConfiguration(new MotelConfiguration());
            modelBuilder.AddConfiguration(new MotelAddressConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
