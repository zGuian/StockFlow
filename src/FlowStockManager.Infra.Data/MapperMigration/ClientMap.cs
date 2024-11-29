using FlowStockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace FlowStockManager.Infra.Data.MapperMigration
{
    internal class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever();

            builder.Property(c => c.Name)
                .HasMaxLength(40)
                .IsRequired(true);

            builder.Property(c => c.Email)
                .HasMaxLength(40)
                .IsRequired(true);

            builder.Property(c => c.Phone)
                .HasConversion(
               v => Regex.Replace(v, @"(\d{2})(\d{9})", "($1)$2-####-####"),
                v => v.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""));

            builder.Property(c => c.DeliveryAddress)
                .IsRequired(true);
        }
    }
}
