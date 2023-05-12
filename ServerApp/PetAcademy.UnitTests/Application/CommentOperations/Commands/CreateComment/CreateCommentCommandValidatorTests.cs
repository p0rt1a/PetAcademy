using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.CommentOperations.Commands.CreateComment;
using Xunit;

namespace PetAcademy.UnitTests.Application.CommentOperations.Commands.CreateComment
{
    public class CreateCommentCommandValidatorTests
    {
        [Theory]
        [InlineData("   ", 0, 0)]
        [InlineData(" ", 1, 1)]
        [InlineData("Valid Body", 0, 0)]
        [InlineData("Valid Body", 1, 0)]
        [InlineData("  ", -2, 1)]
        [InlineData("Valid Body", -1, 1)]
        [InlineData("Valid Body", 0, 1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string body, int userId, int trainingId)
        {
            CreateCommentCommand command = new(null, null);
            command.Model = new CreateCommentModel()
            {
                Body = body,
                UserId = userId,
                TrainingId = trainingId
            };

            CreateCommentCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateCommentCommand command = new(null, null);
            command.Model = new CreateCommentModel()
            {
                Body = "WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError",
                UserId = 1,
                TrainingId = 1
            };

            CreateCommentCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }
    }
}
