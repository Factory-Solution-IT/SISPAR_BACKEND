using FluentValidation;
using Sispar.Domain.Entities;

namespace Sispar.Core.Entities.Validators
{
    public class TitheValidator: AbstractValidator<Tithe>
    {
        public TitheValidator()
        {
            RuleFor(a => a.ValueContribution)
                .GreaterThan(0);

            RuleFor(a => a.TitherId)
                .NotEmpty();
        }
    }
}