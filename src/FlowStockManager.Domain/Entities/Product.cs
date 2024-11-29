using FlowStockManager.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    [NotMapped]
    [CheckMinimalStockQuantity]
    public int MinimalStockQuantity { get; private set; }

    public virtual Supplier? Supplier { get; private set; }
    public Guid SupplierId { get; private set; }

    [NotMapped]
    public int QtdValueProduct { get; private set; }
    public virtual ICollection<OrderProduct>? Orders { get; private set; }

    public static class Factories
    {
        public static Product NewProduct(string name, string? description, decimal price, int stockQuantity,
            Guid supplierId)
        {
            return new Product(name, description, price, stockQuantity, supplierId);
        }

        public static Product Product(Guid id, string name, string? description, decimal price, int stockQuantity,
            Guid supplierId)
        {
            return new Product(id, name, description, price, stockQuantity, supplierId);
        }
    }

    public static List<Product> ConsumeProducts(IEnumerable<Product> products)
    {
        var listProduct = new List<Product>();
        foreach (var product in products)
        {
            product.StockQuantity -= product.QtdValueProduct;
            listProduct.Add(product);
        }
        return listProduct;
    }

    private Product(string name, string? description, decimal price, int stockQuantity, Guid supplierId)
    {
        Id = Guid.NewGuid();
        Name = name.ToLower().Trim();
        Description = description.ToLower().Trim();
        Price = price;
        StockQuantity = stockQuantity;
        SupplierId = supplierId;
    }

    private Product(Guid id, string name, string? description, decimal price, int stockQuantity, Guid supplierId)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
        SupplierId = supplierId;
    }
}