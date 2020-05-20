using FluentValidation;
using Sispar.Domain.Entities;

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
            // .Matches(@"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/")
            // .WithMessage("CPF inválido");
        }
    }
}