using FlowStockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

#pragma warning disable IDE0290

namespace FlowStockManager.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
    }
}
