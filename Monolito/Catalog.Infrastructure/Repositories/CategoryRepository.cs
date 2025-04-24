using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogDbContext _context;

        public CategoryRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task<Category?> GetByIdAsync(Guid id) => await _context.Categories.FindAsync(id);

        public async Task<IList<Category>> GetAllAsync() => await _context.Categories.ToListAsync<Category>();

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _context.Categories.Remove(await GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(id)));
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Category>> GetListAsync() => await _context.Categories.ToListAsync<Category>();

        public async Task UpdateAsync(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
