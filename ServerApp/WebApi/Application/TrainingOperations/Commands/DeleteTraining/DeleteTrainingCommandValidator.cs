using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.TrainingOperations.Commands.DeleteTraining
{
    public class DeleteTrainingCommandValidator : AbstractValidator<DeleteTrainingCommand>
    {
        public DeleteTrainingCommandValidator()
        {
            RuleFor(command => command.TrainingId).GreaterThan(0);
        }
    }
}
