using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Catalog.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>       
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID do produto é obrigatório.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .Length(2, 100).WithMessage("O nome do produto deve ter entre 2 e 100 caracteres.");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");
            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("O estoque do produto não pode ser negativo.");
        }
    }
}
