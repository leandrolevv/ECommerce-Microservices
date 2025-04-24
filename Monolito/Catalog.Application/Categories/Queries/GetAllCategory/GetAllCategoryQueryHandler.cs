using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using MediatR;

namespace Catalog.Application.Categories.Queries.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IList<Category>>
    {
        private readonly ICategoryRepository _repository;
        public GetAllCategoryQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<IList<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
