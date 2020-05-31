using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Core.Entities.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.Username)
                .NotEmpty();

            RuleFor(a => a.Password)
                .NotEmpty();

            RuleFor(a => a.FirstName)
                .NotEmpty();

            RuleFor(a => a.LastName)
                .NotEmpty();
        }
    }
}
