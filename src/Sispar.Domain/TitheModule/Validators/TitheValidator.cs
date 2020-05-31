using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.TitheModule.Validators
{
    public class TitheValidator : AbstractValidator<Tithe>
    {
        public TitheValidator()
        {
            RuleFor(a => a.ValueContribution)
                .GreaterThan(0);

            RuleFor(a => a.DateContribution)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow);

            RuleFor(a => a.TitherId)
                .NotEmpty();
        }
    }
}
