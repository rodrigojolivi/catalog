using FluentValidation;

namespace Catalog.Core.Application.Features.Products.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Category).IsInEnum().WithMessage("A categoria deverá ser de 1 à 4");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório");

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("O preço deverá ser maior que 0");

            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("A quantidade deverá ser maior que 0");
        }
    }
}
