using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowStockManager.Infra.Data.MapperMigration
{
    internal class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("pedidos");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .ValueGeneratedNever();

            builder.HasOne(o => o.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.ClientId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(o => o.OrderDate)
                .IsRequired(true);

            builder.Property(o => o.OrderStatus)
                .HasConversion(v => v.ToString(),
                v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v))
                .IsRequired(true);
        }
    }
}
