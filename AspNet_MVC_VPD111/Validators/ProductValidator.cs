using DataAccess.Data.Entities;
using FluentValidation;
using System;

namespace AspNet_MVC_VPD111.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name)
                .NotNull()
                .MaximumLength(100);
            RuleFor(x => x.Price)
                .NotEqual(0).WithMessage("Price is required value.")
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Discount).InclusiveBetween(0, 100);
            RuleFor(x => x.Description).Length(10, 1000);
            RuleFor(x => x.ImageUrl)
                .Must(ValidateUri).WithMessage("{PropertyName} must be a valid URL address");
        }

        public bool ValidateUri(string? uri)
        {
            // just so the validation passes if the uri is not required / nullable
            if (string.IsNullOrEmpty(uri))
            {
                return true;
            }
            return Uri.TryCreate(uri, UriKind.Absolute, out _);
        }
    }
}
