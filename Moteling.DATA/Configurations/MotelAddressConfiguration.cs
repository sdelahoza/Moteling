using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moteling.DATA.Entities;

namespace Moteling.DATA.Configurations
{
    public class MotelAddressConfiguration : BaseConfiguration<MotelAddress, int>
    {
        public MotelAddressConfiguration()
            : base("MotelAddress", "MotelId")
        {

        }

        public override void NextConfigurations(EntityTypeBuilder<MotelAddress> entity)
        {
            entity.Property(p => p.Address)
                .IsUnicode(true)
                .IsRequired()
                .HasMaxLength(1000);

            entity.Property(p => p.Latitude);

            entity.Property(p => p.Longitude);

            entity.Property(p => p.City)
                .IsUnicode(true)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(p => p.Country)
                .IsUnicode(true)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
