using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.PetOperations.Commands.UpdatePet;
using Xunit;

namespace PetAcademy.UnitTests.Application.PetOperations.Command.UpdatePet
{
    public class UpdatePetCommandValidatorTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int petId, int userId)
        {
            UpdatePetCommand command = new(null, null);
            command.PetId = petId;
            command.Model = new UpdatePetModel()
            {
                Name = "WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors",
                Age = 2,
                UserId = userId
            };

            UpdatePetCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            UpdatePetCommand command = new(null, null);
            command.PetId = 1;
            command.Model = new UpdatePetModel()
            {
                Name = "WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError",
                Age = 2,
                UserId = 1
            };

            UpdatePetCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
