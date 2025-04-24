﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand(string Name) : IRequest<Guid>;
}
