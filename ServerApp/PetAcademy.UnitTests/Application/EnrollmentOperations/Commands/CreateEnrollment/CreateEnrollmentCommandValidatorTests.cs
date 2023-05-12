using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.CommentOperations.Commands.CreateComment;
using WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment;
using Xunit;

namespace PetAcademy.UnitTests.Application.EnrollmentOperations.Commands.CreateEnrollment
{
    public class CreateEnrollmentCommandValidatorTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(-1, 1)]
        [InlineData(1, -1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int petId, int trainingId)
        {
            CreateEnrollmentCommand command = new(null, null);
            command.Model = new CreateEnrollmentModel()
            {
                PetId = petId,
                TrainingId = trainingId
            };

            CreateEnrollmentCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateEnrollmentCommand command = new(null, null);
            command.Model = new CreateEnrollmentModel()
            {
                PetId = 1,
                TrainingId = 1
            };

            CreateEnrollmentCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }
    }
}
