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
    public virtual ICollection<Product> Products { get; private set; } = null!;

    public static class Factories
    {
        public static Supplier NewSupplier(string name, string? contact, string? address)
        {
            return new Supplier(name, contact, address);
        }
    }

    public Supplier() { }

    private Supplier(string name, string? contact, string? address)
    {
        Id = Guid.NewGuid();
        Name = name.ToLower().Trim();
        Contact = contact.ToLower().Trim();
        Address = address.ToLower().Trim();
    }
}