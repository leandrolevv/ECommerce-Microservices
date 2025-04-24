using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Products.Queries.GetAllProduct
{
    public record GetAllProductQuery() : IRequest<IList<Product>>;
}
