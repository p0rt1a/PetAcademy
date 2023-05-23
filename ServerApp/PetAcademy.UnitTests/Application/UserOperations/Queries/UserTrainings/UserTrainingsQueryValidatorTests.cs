using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.UserOperations.Queries.UserTrainings;
using Xunit;

namespace PetAcademy.UnitTests.Application.UserOperations.Queries.UserTrainings
{
    public class UserTrainingsQueryValidatorTests
    {
        [Fact]
        public void WhenInvalidUserIdIsGiven_Validator_ShouldBeReturnError()
        {
            UserTrainingsQuery query = new(null, null);
            query.UserId = 0;

            UserTrainingsQueryValidator validator = new();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidUserIdIsGiven_Validator_ShouldNotBeReturnError()
        {
            UserTrainingsQuery query = new(null, null);
            query.UserId = 1;

            UserTrainingsQueryValidator validator = new();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Equals(0);
        }
    }
}
