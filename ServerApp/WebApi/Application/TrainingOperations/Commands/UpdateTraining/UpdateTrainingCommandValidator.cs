using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.TrainingOperations.Commands.UpdateTraining
{
    public class UpdateTrainingCommandValidator : AbstractValidator<UpdateTrainingCommand>
    {
        public UpdateTrainingCommandValidator()
        {
            RuleFor(command => command.TrainingId).GreaterThan(0);
        }
    }
}
