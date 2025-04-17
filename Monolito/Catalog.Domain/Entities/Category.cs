using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Common;

namespace Catalog.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
