using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.AuthOperations.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(command => command.Model.Email.Trim()).NotEmpty().MinimumLength(8);
            RuleFor(command => command.Model.Name.Trim()).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Surname.Trim()).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Password.Trim()).NotEmpty().MinimumLength(8);
        }
    }
}
