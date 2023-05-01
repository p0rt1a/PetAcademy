using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.PetOperations.Commands.UpdatePet
{
    public class UpdatePetCommandValidator : AbstractValidator<UpdatePetCommand>
    {
        public UpdatePetCommandValidator()
        {
            RuleFor(command => command.Model.UserId).GreaterThan(0);
            RuleFor(command => command.PetId).GreaterThan(0);
        }
    }
}
