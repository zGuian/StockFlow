using FlowStockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowStockManager.Infra.Data.MapperMigration
{
    internal class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("clientes");

            builder.Property(c => c.Id)
                .ValueGeneratedNever();

            builder.Property(c => c.Name)
                .HasMaxLength(40)
                .IsRequired(true);

            builder.Property(c => c.Email)
                .HasMaxLength(40)
                .IsRequired(true);

            builder.Property(c => c.Phone)
                .HasMaxLength(12)
                .IsRequired(false);

            builder.Property(c => c.DeliveryAddress)
                .IsRequired(true);

            builder.Property(c => c.IsActive)
                .IsRequired(true);
        }
    }
}
