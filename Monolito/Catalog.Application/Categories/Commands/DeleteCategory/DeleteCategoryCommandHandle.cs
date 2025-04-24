using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Interfaces;
using MediatR;

namespace Catalog.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandl : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public DeleteCategoryCommandHandl(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            
            await _categoryRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
