using System.ComponentModel.DataAnnotations;
using FlowStockManager.Domain.Validation;

namespace FlowStockManager.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    
    [MinLength(3), MaxLength(100)]
    public string Name { get; private set; }
    
    [MaxLength(500)]
    public string? Description { get; private set; }
    
    [CheckPrice]
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }
    
    [CheckMinimalStockQuantity]
    public int MinimalStockQuantity { get; private set; }
    public Supplier Supplier { get; private set; }
    
    public static class Factories
    {
        public static Product NewProduct(string name, string? description, decimal price, int stockQuantity,
            int minimalStockQuantity, Supplier supplier)
        {
            return new Product(name, description, price, stockQuantity, minimalStockQuantity, supplier);
        }
    }

    private Product(string name, string? description, decimal price, int stockQuantity, int minimalStockQuantity, Supplier supplier)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
        MinimalStockQuantity = minimalStockQuantity;
        Supplier = supplier;
    }
}