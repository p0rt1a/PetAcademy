using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.PetOperations.Commands.DeletePet;
using Xunit;

namespace PetAcademy.UnitTests.Application.PetOperations.Command.DeletePet
{
    public class DeletePetCommandValidatorTests
    {
        [Fact]
        public void WhenInvalidPetIdIsGiven_Validator_ShouldBeReturnError()
        {
            DeletePetCommand command = new(null);
            command.PetId = 0;

            DeletePetCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidPetIdIsGiven_Validator_ShouldNotBeReturnError()
        {
            DeletePetCommand command = new(null);
            command.PetId = 1;

            DeletePetCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
