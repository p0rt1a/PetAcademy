using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.TrainingOperations.Commands.CreateTraining
{
    public class CreateTrainingCommandValidator : AbstractValidator<CreateTrainingCommand>
    {
        public CreateTrainingCommandValidator()
        {
            RuleFor(command => command.Model.Title.Trim()).MinimumLength(8);
            RuleFor(command => command.Model.Description.Trim()).MinimumLength(10);
            RuleFor(command => command.Model.City.Trim()).MinimumLength(2);
            RuleFor(command => command.Model.Address.Trim()).MinimumLength(2);
            RuleFor(command => command.Model.Price).GreaterThan(0);
            RuleFor(command => command.Model.UserId).GreaterThan(0);
        }
    }
}
