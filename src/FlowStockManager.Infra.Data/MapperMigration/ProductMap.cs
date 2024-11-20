using FlowStockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowStockManager.Infra.Data.MapperMigration
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("produto");
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(p => p.Name)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(p => p.Price)
                .IsRequired(true);

            builder.Property(p => p.StockQuantity)
                .IsRequired(true);

            builder.Property(p => p.MinimalStockQuantity)
                .IsRequired(true);

            builder.Ignore(p => p.Supplier);
        }
    }
}
