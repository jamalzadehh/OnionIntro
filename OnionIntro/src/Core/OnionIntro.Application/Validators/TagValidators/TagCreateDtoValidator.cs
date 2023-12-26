using FluentValidation;
using OnionIntro.Application.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.Validators.TagValidators
{
    public class TagCreateDtoValidator : AbstractValidator<CategoryCreateDto>
    {
        public TagCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(1).Matches("^[a-zA-z0-9 ]$");
        }
    }
}
