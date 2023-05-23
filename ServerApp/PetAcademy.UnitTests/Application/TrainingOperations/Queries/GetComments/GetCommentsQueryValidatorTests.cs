using AutoMapper;
using FluentAssertions;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.TrainingOperations.Queries.GetComments;
using WebApi.DbOperations;
using Xunit;

namespace PetAcademy.UnitTests.Application.TrainingOperations.Queries.GetComments
{
    public class GetCommentsQueryValidatorTests
    {
        [Fact]
        public void WhenInvalidTrainingIdIsGiven_Validator_ShouldBeReturnError()
        {
            GetCommentsQuery query = new(null, null);
            query.TrainingId = 0;

            GetCommentsQueryValidator validator = new();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
