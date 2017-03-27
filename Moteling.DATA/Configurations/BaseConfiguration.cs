using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moteling.DATA.Entities;
using Moteling.DATA.Infrastructure;

namespace Moteling.DATA.Configurations
{
    public class BaseConfiguration<TEntity, K> : DbEntityConfiguration<TEntity>
        where TEntity : BaseEntity<K>
        where K : struct
    {
        string tableName;
        string idName;

        public BaseConfiguration(string tableName, string idName)
        {
            this.tableName = tableName;
            this.idName = idName;
        }

        public override void Configure(EntityTypeBuilder<TEntity> entity)
        {
            entity.ForSqlServerToTable(tableName);

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id)
                .HasColumnName(idName);

            NextConfigurations(entity);
        }

        public virtual void NextConfigurations(EntityTypeBuilder<TEntity> entity) { }
    }
}
