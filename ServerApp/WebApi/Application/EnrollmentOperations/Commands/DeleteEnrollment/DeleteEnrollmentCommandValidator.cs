using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.EnrollmentOperations.Commands.DeleteEnrollment
{
    public class DeleteEnrollmentCommandValidator : AbstractValidator<DeleteEnrollmentCommand>
    {
        public DeleteEnrollmentCommandValidator()
        {
            RuleFor(command => command.PetId).GreaterThan(0);
            RuleFor(command => command.TrainingId).GreaterThan(0);
        }
    }
}
