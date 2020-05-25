using FluentValidation;
using Sispar.Domain.Entities;
using System;

namespace Sispar.Core.Entities.Validators
{
    public class TitherValidator : AbstractValidator<Tither>
    {
        public TitherValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty();

            RuleFor(a => a.Address)
                .NotEmpty();

            RuleFor(a => a.CPF)
                .NotEmpty();

            RuleFor(a => a.BirthDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow);
            // .Matches(@"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/")
            // .WithMessage("CPF inválido");
        }
    }
}