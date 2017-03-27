using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moteling.DATA.Entities;

namespace Moteling.DATA.Configurations
{
    public class RoomImageConfiguration : BaseConfiguration<RoomImage, long>
    {
        public RoomImageConfiguration()
            : base("RoomImage", "ImageId")
        {

        }

        public override void NextConfigurations(EntityTypeBuilder<RoomImage> entity)
        {
            entity.Property(p => p.ImageUrl)
                .IsUnicode(true)
                .IsRequired()
                .HasMaxLength(2000);

            entity.Property(p => p.RoomId);
        }
    }
}
