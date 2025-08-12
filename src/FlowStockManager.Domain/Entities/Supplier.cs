using System.ComponentModel.DataAnnotations;

namespace FlowStockManager.Domain.Entities;

public class Supplier : EntityBase
{    
    [MinLength(3), MaxLength(100)]
    public string Name { get; private set; }
    public string? Contact { get; private set; }
    
    [MaxLength(250)]
    public string? Address { get; private set; }
    public virtual ICollection<Product> Products { get; private set; } = null!;

    private Supplier(string id, string name, string? contact, string? address) : base(id)
    {
        Name = name;
        Contact = contact;
        Address = address;
    }

    public static class Factories
    {
        public static Supplier NewSupplier(string name, string? contact, string? address)
        {
            return new Supplier(GenerateId(), name, contact, address);
        }
    }
}