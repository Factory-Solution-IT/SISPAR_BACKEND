using FluentValidation;
using Sispar.Domain.Entities;
using System;

namespace Sispar.Core.Entities.Validators
{
    public class TitheValidator: AbstractValidator<Tithe>
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