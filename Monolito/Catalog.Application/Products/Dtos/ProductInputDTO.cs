using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Products.Dtos
{
    public record ProductInputDTO(string Name, decimal Price, int Stock);
}
