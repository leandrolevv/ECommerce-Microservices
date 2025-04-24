using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data
{
    public class CatalogDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);


             modelBuilder.Entity<Category>().HasData(
                new Category { Id = Guid.Parse("58a45108-6fb5-410c-92a2-3ca63081be2c"), Name = "Eletrônicos", CreatedAt = new DateTime(2025, 4, 22, 23, 38, 28, DateTimeKind.Utc) },
                new Category { Id = Guid.Parse("9a2342ca-61bd-421e-ba39-0d66f999e7f6"), Name = "Livros", CreatedAt = new DateTime(2025, 4, 22, 23, 38, 28, DateTimeKind.Utc) }
            );
        }
    }
}
