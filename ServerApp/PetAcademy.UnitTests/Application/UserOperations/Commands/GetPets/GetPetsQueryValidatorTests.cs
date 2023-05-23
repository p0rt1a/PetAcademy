using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.UserOperations.Queries.GetPets;
using Xunit;

namespace PetAcademy.UnitTests.Application.UserOperations.Commands.GetPets
{
    public class GetPetsQueryValidatorTests
    {
        [Fact]
        public void WhenInvalidUserIdIsGiven_Validator_ShouldBeReturnError()
        {
            GetPetsQuery query = new(null, null);
            query.UserId = 0;

            GetPetsQueryValidator validator = new();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenInvalidUserIdIsGiven_Validator_ShouldNotBeReturnError()
        {
            GetPetsQuery query = new(null, null);
            query.UserId = 1;

            GetPetsQueryValidator validator = new();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Equals(0);
        }
    }
}
