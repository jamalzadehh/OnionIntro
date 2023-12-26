using FluentValidation;
using OnionIntro.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.Validators.ProductValidators
{
    public class ProductCreateDtoValidator:AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is important")
                .MaximumLength(100).WithMessage("Name may contain maximum 50 characters")
                .MinimumLength(2).WithMessage("Name may conatin at least 2 characters");
                
            RuleFor(x => x.SKU).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Price).NotEmpty().LessThanOrEqualTo(999999.99m).GreaterThanOrEqualTo(10);
            RuleFor(x => x.Description).MaximumLength(1000);
            RuleFor(p => p.CategoryId).Must(c=>c>0).WithMessage("You must include correct category id");

            RuleForEach(x => x.ColorIds).Must(c => c > 0).WithMessage("You must include correct color id");
            RuleForEach(x => x.TagIds).Must(c => c > 0).WithMessage("You must include correct tag id");
            RuleFor(p => p.ColorIds).NotEmpty().WithMessage("You must include color id");
            RuleFor(p => p.TagIds).NotEmpty().WithMessage("You must include tag id");

        }
        
    }
}
