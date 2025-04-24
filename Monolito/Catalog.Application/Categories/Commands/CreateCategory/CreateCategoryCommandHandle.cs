using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandle : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _repository;
        public CreateCategoryCommandHandle(ICategoryRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(category);
            return category.Id;
        }
    }
}
