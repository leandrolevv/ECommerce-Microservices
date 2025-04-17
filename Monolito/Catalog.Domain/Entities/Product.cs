using Catalog.Domain.Common;

namespace Catalog.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}