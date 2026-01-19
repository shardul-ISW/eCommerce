using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Models.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }

    public abstract class EntityConfiguration<TEntity>
    : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {   
            //Set Id as Primary Key
            builder.HasKey(e => e.Id);
            //Configure Postgres to generate the UUID for Id
            builder.Property(e => e.Id).HasDefaultValueSql("uuidv7()");

            ConfigureEntity(builder);
        }

        protected virtual void ConfigureEntity(EntityTypeBuilder<TEntity> builder) { }
    }
}
