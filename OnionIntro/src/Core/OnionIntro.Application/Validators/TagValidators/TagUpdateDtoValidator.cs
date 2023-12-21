using FluentValidation;
using OnionIntro.Application.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.Validators.TagValidators
{
    internal class TagUpdateDtoValidator:AbstractValidator<TagUpdateDto>
    {
        public TagUpdateDtoValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(50).MinimumLength(1);
        }
    }
}
