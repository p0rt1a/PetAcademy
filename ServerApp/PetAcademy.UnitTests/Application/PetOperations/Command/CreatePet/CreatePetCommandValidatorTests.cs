using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.PetOperations.Commands.CreatePet;
using Xunit;

namespace PetAcademy.UnitTests.Application.PetOperations.Command.CreatePet
{
    public class CreatePetCommandValidatorTests
    {
        [Theory]
        [InlineData("Valid Name", 20, 1, 0)]
        [InlineData("Valid Name", 0, 0, 0)]
        [InlineData("   ", 0, 0, 0)]
        [InlineData(" ", 1, 0 ,0)]
        [InlineData("Valid Name", 1, 0, 1)]
        [InlineData(" ", 0, 1, 1)]
        [InlineData("V", 1, 1, 1)]
        [InlineData("Val", 1, 1, 0)]
        [InlineData("Valid Name", 0, 0, 1)]
        [InlineData("Vali", -2, -4, -7)]
        [InlineData("Val", -2, 1, 1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, int age, int userId, int genreId)
        {
            CreatePetCommand command = new(null, null);
            command.Model = new CreatePetModel()
            {
                Name = name,
                Age = age,
                UserId = userId,
                GenreId = genreId
            };

            CreatePetCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("Valid Name", 10, 1, 1)]
        [InlineData("Val", 1, 3, 5)]
        [InlineData("Va", 1, 80, 100)]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError(string name, int age, int userId, int genreId)
        {
            CreatePetCommand command = new(null, null);
            command.Model = new CreatePetModel()
            {
                Name = name,
                Age = age,
                UserId = userId,
                GenreId = genreId
            };

            CreatePetCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }
    }
}
