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
    public class GetCommentsQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public GetCommentsQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenDoesntExistTrainingIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            GetCommentsQuery query = new(_context, _mapper);
            query.TrainingId = 0;

            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Eğitim mevcut değil!");
        }

        [Fact]
        public void WhenAlreadyExistTraininIdIsGiven_TrainingComments_ShouldBeReturn()
        {
            GetCommentsQuery query = new(_context, _mapper);
            query.TrainingId = 1;

            var result = FluentActions.Invoking(() => query.Handle()).Invoke();

            result.Should().NotBeNull();
        }
    }
}
