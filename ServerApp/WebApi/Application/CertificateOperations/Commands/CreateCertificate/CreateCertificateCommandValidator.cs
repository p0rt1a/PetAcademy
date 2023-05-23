using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.CertificateOperations.Commands.CreateCertificate
{
    public class CreateCertificateCommandValidator : AbstractValidator<CreateCertificateCommand>
    {
        public CreateCertificateCommandValidator()
        {
            RuleFor(command => command.Model.PetId).GreaterThan(0);
            RuleFor(command => command.Model.TrainingId).GreaterThan(0);
        }
    }
}
