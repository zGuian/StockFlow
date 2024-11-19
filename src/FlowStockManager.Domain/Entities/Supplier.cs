using System.ComponentModel.DataAnnotations;

namespace FlowStockManager.Domain.Entities;

public class Supplier
{
    public Guid Id { get; private set; }
    
    [MinLength(3), MaxLength(100)]
    public string Name { get; private set; }
    public string? Contact { get; private set; }
    
    [MaxLength(250)]
    public string? Address { get; private set; }
    public virtual ICollection<Product> Product { get; private set; }

    private Supplier(string name, string? contact, string? address, Product product)
    {
        Id = Guid.NewGuid();
        Name = name;
        Contact = contact;
        Address = address;
        Product.Add(product);
    }

    public static class Factories
    {
        public static Supplier NewSupplier(string name, string? contact, string? address, Product product)
        {
            return new Supplier(name, contact, address, product);
        }
    }
}