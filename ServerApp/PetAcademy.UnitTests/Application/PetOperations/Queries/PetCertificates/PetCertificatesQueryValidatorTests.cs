using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.PetOperations.Queries.PetCertificates;
using Xunit;

namespace PetAcademy.UnitTests.Application.PetOperations.Queries.PetCertificates
{
    public class PetCertificatesQueryValidatorTests
    {
        [Fact]
        public void WhenInvalidPetIdIsGiven_Validator_ShouldBeReturnError()
        {
            PetCertificatesQuery query = new(null, null);
            query.PetId = 0;

            PetCertificatesQueryValidator validator = new();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidPetIdIsGiven_Validator_ShouldNotBeReturnError()
        {
            PetCertificatesQuery query = new(null, null);
            query.PetId = 1;

            PetCertificatesQueryValidator validator = new();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Equals(0);
        }
    }
}
