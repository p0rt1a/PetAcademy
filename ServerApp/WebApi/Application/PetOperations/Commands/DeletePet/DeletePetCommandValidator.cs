using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.PetOperations.Commands.DeletePet
{
    public class DeletePetCommandValidator  :AbstractValidator<DeletePetCommand>
    {
        public DeletePetCommandValidator()
        {
            RuleFor(command => command.PetId).GreaterThan(0);
        }
    }
}
