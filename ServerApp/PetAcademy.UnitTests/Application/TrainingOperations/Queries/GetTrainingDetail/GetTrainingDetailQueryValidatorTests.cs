using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.TrainingOperations.Queries.GetTrainingDetail;
using Xunit;

namespace PetAcademy.UnitTests.Application.TrainingOperations.Queries.GetTrainingDetail
{
    public class GetTrainingDetailQueryValidatorTests
    {
        [Fact]
        public void WhenInvalidTrainingIdIsGiven_Validator_ShouldBeReturnError()
        {
            GetTrainingDetailQuery query = new(null, null);
            query.TrainingId = 0;

            GetTrainingDetailQueryValidator validator = new();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
