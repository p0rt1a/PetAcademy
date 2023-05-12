using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.PetOperations.Queries.PetDetail;
using Xunit;

namespace PetAcademy.UnitTests.Application.PetOperations.Queries.PetDetail
{
    public class PetDetailQueryValidatorTests
    {
        [Fact]
        public void WhenInvalidPetIdIsGiven_Validator_ShouldBeReturnError()
        {
            PetDetailQuery query = new(null, null);
            query.PetId = 0;

            PetDetailQueryValidator validator = new();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            PetDetailQuery query = new(null, null);
            query.PetId = 1;

            PetDetailQueryValidator validator = new();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Equals(0);
        }
    }
}
