using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.TrainingOperations.Commands.UpdateTraining;
using Xunit;

namespace PetAcademy.UnitTests.Application.TrainingOperations.Commands.UpdateTraining
{
    public class UpdateTrainingCommandValidatorTests
    {
        [Fact]
        public void WhenInvalidTrainingIdIsGiven_Validator_ShouldBeReturnError()
        {
            UpdateTrainingCommand command = new(null);
            command.TrainingId = 0;

            UpdateTrainingCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidTrainingIdIsGiven_Validator_ShouldNotBeReturnError()
        {
            UpdateTrainingCommand command = new(null);
            command.TrainingId = 7;

            UpdateTrainingCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }
    }
}
