using FluentValidation;
using ProductService.RequestModels;

namespace ProductService.Validators
{
    public class ProductRequestValidator : AbstractValidator<ProductRequest>
    {
        public ProductRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MinimumLength(2);
            RuleFor(p => p.Price).GreaterThan(0);
        }
    }
}