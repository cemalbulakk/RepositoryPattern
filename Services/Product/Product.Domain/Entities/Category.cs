using Product.Domain.Base;

namespace Product.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}