using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using MediatR;

namespace Catalog.Application.Products.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IList<Product>>
    {
        private readonly IProductRepository _repository;
        public GetAllProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<IList<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
