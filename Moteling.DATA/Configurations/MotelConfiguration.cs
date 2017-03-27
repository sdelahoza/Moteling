using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moteling.DATA.Entities;

namespace Moteling.DATA.Configurations
{
    public class MotelConfiguration : BaseConfiguration<Motel, int>
    {
        public MotelConfiguration()
            : base("Motel", "MotelId")
        {

        }

        public override void NextConfigurations(EntityTypeBuilder<Motel> entity)
        {
            entity.Property(p => p.Name)
                .IsUnicode(true)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(p => p.PhoneNumber)
                .IsUnicode(true)
                .HasMaxLength(500);

            entity.Property(p => p.Page)
                .IsUnicode(true)
                .HasMaxLength(500);

            entity.Property(p => p.Description)
                .IsUnicode(true)
                .HasMaxLength(2000);

            #region Relationships
            entity.HasMany(p => p.Rooms)
                .WithOne();

            entity.HasOne(p => p.Address)
                .WithOne(i => i.Motel)
                .HasForeignKey<MotelAddress>(b => b.Id);
            #endregion
        }
    }
}
