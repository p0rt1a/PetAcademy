using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.CertificateOperations.Commands.CreateCertificate;
using Xunit;

namespace PetAcademy.UnitTests.Application.CertificateOperations.Commands.CreateCertificate
{
    public class CreateCertificateCommandValidatorTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1,0)]
        [InlineData(0,1)]
        [InlineData(-2, 1)]
        [InlineData(-3, -7)]
        [InlineData(2, -2)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int petId, int trainingId)
        {
            CreateCertificateCommand command = new(null, null);
            command.Model = new CreateCertificateModel()
            {
                PetId = petId,
                TrainingId = trainingId
            };

            CreateCertificateCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(7, 2)]
        public void WhenValidInputsAreGiven_Validator_ShouldBeReturnErrors(int petId, int trainingId)
        {
            CreateCertificateCommand command = new(null, null);
            command.Model = new CreateCertificateModel()
            {
                PetId = petId,
                TrainingId = trainingId
            };

            CreateCertificateCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }
    }
}
