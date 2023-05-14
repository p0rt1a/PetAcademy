using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.UserOperations.Queries.UserDetail;
using Xunit;

namespace PetAcademy.UnitTests.Application.UserOperations.Queries.UserDetail
{
    public class UserDetailQueryValidatorTests
    {
        [Fact]
        public void WhenInvalidUserIdIsGiven_Validator_ShouldBeReturnError()
        {
            UserDetailQuery query = new(null, null);
            query.UserId = 0;

            UserDetailQueryValidator validator = new();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidUserIdIsGiven_Validator_ShouldNotBeReturnError()
        {
            UserDetailQuery query = new(null, null);
            query.UserId = 1;

            UserDetailQueryValidator validator = new();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Equals(0);
        }
    }
}
