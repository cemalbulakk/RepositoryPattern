using Product.Domain.Base;

namespace Product.Domain.Entities;

public class Product : BaseEntity
{
    public string Code { get; set; }
    public string Name { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}