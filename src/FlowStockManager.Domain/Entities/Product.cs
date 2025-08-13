using FlowStockManager.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace FlowStockManager.Domain.Entities
{
    public class Product : EntityBase
    {
        [MinLength(3), MaxLength(100)]
        public string Name { get; private set; }

        [MaxLength(500)]
        public string? Description { get; private set; }

        [CheckPrice]
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }

        [CheckMinimalStockQuantity]
        public int MinimalStockQuantity { get; private set; }
        public virtual Supplier? Supplier { get; private set; }
        public string SupplierId { get; private set; }

        public static class Factories
        {
            public static Product NewProduct(string name, string? description, decimal price, int stockQuantity,
                string supplierId)
            {
                return new Product(GenerateId(), name, description, price, stockQuantity, supplierId);
            }
        }

        public void ConsumeProduct(int quantity)
        {
            if (StockQuantity > quantity)
            {
                StockQuantity -= quantity;
            }
        }

        private Product(string id, string name, string? description, decimal price, int stockQuantity, 
            string supplierId) : base(id)
        {
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
            SupplierId = supplierId;
        }
    }
}