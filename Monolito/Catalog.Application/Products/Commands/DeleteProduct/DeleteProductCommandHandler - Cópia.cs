using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Interfaces;
using MediatR;

namespace Catalog.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandlerCopia : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        
        public DeleteProductCommandHandlerCopia(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
                throw new KeyNotFoundException($"Produto com ID {request.Id} não encontrado.");

            await _productRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
