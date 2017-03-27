using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moteling.DATA.Infrastructure
{
    public abstract class DbEntityConfiguration<TEntity> where TEntity : class
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> entity);
    }
}
