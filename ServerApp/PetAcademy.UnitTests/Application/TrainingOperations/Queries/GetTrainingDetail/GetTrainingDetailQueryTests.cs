using AutoMapper;
using FluentAssertions;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.TrainingOperations.Queries.GetTrainingDetail;
using WebApi.DbOperations;
using Xunit;

namespace PetAcademy.UnitTests.Application.TrainingOperations.Queries.GetTrainingDetail
{
    public class GetTrainingDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public GetTrainingDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenDoesNotExistTrainingIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            GetTrainingDetailQuery query = new(_context, _mapper);
            query.TrainingId = 0;

            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Eğitim bulunamadı");
        }

        [Fact]
        public void WhenExistTrainingIdIsGiven_Training_ShouldBeReturn()
        {
            GetTrainingDetailQuery query = new(_context, _mapper);
            query.TrainingId = 1;

            var training = FluentActions.Invoking(() => query.Handle()).Invoke();

            training.Title.Should().NotBeNullOrEmpty();
            training.Description.Should().NotBeNullOrEmpty();
            training.Price.Should().BeGreaterThan(0);
            training.MaxPetCount.Should().BeGreaterThan(0);
            training.Genre.Should().NotBeNullOrEmpty();
        }
    }
}
