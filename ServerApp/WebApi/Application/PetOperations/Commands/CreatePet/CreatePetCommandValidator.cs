using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.PetOperations.Commands.CreatePet
{
    public class CreatePetCommandValidator : AbstractValidator<CreatePetCommand>
    {
        public CreatePetCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.UserId).GreaterThan(0);
            RuleFor(command => command.Model.Name.Trim()).MinimumLength(2);
            RuleFor(command => command.Model.Age).GreaterThan(0);
        }
    }
}
