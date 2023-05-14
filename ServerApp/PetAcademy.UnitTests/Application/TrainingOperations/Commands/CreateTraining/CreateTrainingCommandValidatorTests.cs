using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.TrainingOperations.Commands.CreateTraining;
using Xunit;

namespace PetAcademy.UnitTests.Application.TrainingOperations.Commands.CreateTraining
{
    public class CreateTrainingCommandValidatorTests
    {
        [Theory]
        [InlineData("","","","",0,0)]
        [InlineData("Invalid", "Invalid", "I", "", 0, 0)]
        [InlineData("   ", "    ", "       ", "    ", 1, 0)]
        [InlineData("Valid Title Sample", "Valid Description Sample", "Valid City Sample", "Valid Address", 0, 1)]
        [InlineData("Invalid", "Valid Description Sample", "Valid City Sample", " ", 1, 1)]
        [InlineData("Valid Title Sample", "   ", "   ", "Valid Address", 1, 1)]
        [InlineData("Invalid", "Valid Description Sample", "Valid City Sample", "Valid Address", 1, 1)]
        [InlineData("Valid Title Sample", "Valid Description Sample", "Valid City Sample", "Valid Address", -2, -7)]
        [InlineData("      ", "Valid Description Sample", "       ", "      ", 2, -3)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, string description, string city, string address, decimal price, int userId)
        {
            CreateTrainingCommand command = new(null, null);
            command.Model = new CreateTrainingModel()
            {
                Title = title,
                Description = description,
                City = city,
                Address = address,
                Price = price,
                UserId = userId
            };

            CreateTrainingCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateTrainingCommand command = new(null, null);
            command.Model = new CreateTrainingModel()
            {
                Title = "Valid Title",
                Description = "Valid Description",
                City = "Valid City",
                Address = "Valid Address",
                Price = 10,
                UserId = 1
            };

            CreateTrainingCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
