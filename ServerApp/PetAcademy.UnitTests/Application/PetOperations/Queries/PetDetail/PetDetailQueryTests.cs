using AutoMapper;
using FluentAssertions;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.PetOperations.Queries.PetDetail;
using WebApi.DbOperations;
using Xunit;

namespace PetAcademy.UnitTests.Application.PetOperations.Queries.PetDetail
{
    public class PetDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public PetDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenDoesNotExistPetIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            PetDetailQuery query = new(_context, _mapper);
            query.PetId = 0;

            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Evcil hayvan bulunamadı!");
        }

        [Fact]
        public void WhenAlreadyExistPetIdIsGiven_Pet_ShouldBeReturn()
        {
            PetDetailQuery query = new(_context, _mapper);
            query.PetId = 1;

            var pet = FluentActions.Invoking(() => query.Handle()).Invoke();

            pet.Name.Should().NotBeNullOrEmpty();
            pet.Age.Should().BeGreaterThan(0);
        }
    }
}
