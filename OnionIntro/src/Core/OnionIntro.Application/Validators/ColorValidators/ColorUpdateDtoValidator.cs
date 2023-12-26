using FluentValidation;
using OnionIntro.Application.DTOs.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.Validators.ColorValidators
{
    public class ColorUpdateDtoValidator:AbstractValidator<ColorUpdateDto>
    {
        public ColorUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(1);
        }
    }
}
