using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.TrainingOperations.Commands.DeleteTraining;
using Xunit;

namespace PetAcademy.UnitTests.Application.TrainingOperations.Commands.DeleteTraining
{
    public class DeleteTrainingCommandValidatorTests
    {
        [Fact]
        public void WhenInvalidTrainingIdIsGiven_Validator_ShouldBeReturnError()
        {
            DeleteTrainingCommand command = new(null);
            command.TrainingId = 0;

            DeleteTrainingCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            DeleteTrainingCommand command = new(null);
            command.TrainingId = 1;

            DeleteTrainingCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
