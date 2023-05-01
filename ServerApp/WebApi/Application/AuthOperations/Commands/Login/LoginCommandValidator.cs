using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.AuthOperations.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(command => command.Model.Email.Trim()).NotEmpty().MinimumLength(8);
            RuleFor(command => command.Model.Password.Trim()).NotEmpty().MinimumLength(8);
        }
    }
}
