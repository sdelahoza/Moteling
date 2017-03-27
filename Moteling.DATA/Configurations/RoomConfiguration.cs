using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moteling.DATA.Entities;

namespace Moteling.DATA.Configurations
{
    public class RoomConfiguration : BaseConfiguration<Room, int>
    {
        public RoomConfiguration()
            : base("Room", "RoomId")
        {

        }

        public override void NextConfigurations(EntityTypeBuilder<Room> entity)
        {
            entity.Property(p => p.Name)
                .IsUnicode(true)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(p => p.MotelId);

            #region Relationships
            entity.HasMany(p => p.Images)
                .WithOne();
            #endregion
        }
    }
}
