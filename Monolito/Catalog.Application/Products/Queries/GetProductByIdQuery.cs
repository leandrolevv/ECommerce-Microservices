using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Products.Queries;

public record GetProductByIdQuery(Guid Id) : IRequest<Product>;

