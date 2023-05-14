using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.UserOperations.Commands.UpdateUser;
using Xunit;

namespace PetAcademy.UnitTests.Application.UserOperations.Commands.UpdateUser
{
    public class UpdateUserCommandValidatorTests
    {
        [Theory]
        [InlineData("  ", 0)]
        [InlineData("email@gmail.com", 0)]
        [InlineData("     ", 1)]
        [InlineData("      ", 1)]
        [InlineData("emai", 1)]
        [InlineData("email@", 0)]
        [InlineData("  ", 1)]
        [InlineData("email@hotmail.com", -2)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string email, int id)
        {
            UpdateUserCommand command = new(null);
            command.UserId = id;
            command.Model = new UpdateUserModel()
            {
                Email = email
            };

            UpdateUserCommandValidator validator = new();

            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            UpdateUserCommand command = new(null);
            command.UserId = 1;
            command.Model = new UpdateUserModel()
            {
                Email = "WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError@gmail.com"
            };

            UpdateUserCommandValidator validator = new();

            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }
    }
}
