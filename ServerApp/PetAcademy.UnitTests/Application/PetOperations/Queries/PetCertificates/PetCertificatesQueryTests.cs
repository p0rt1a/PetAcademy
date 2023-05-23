using AutoMapper;
using FluentAssertions;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.PetOperations.Queries.PetCertificates;
using WebApi.DbOperations;
using Xunit;

namespace PetAcademy.UnitTests.Application.PetOperations.Queries.PetCertificates
{
    public class PetCertificatesQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public PetCertificatesQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenDoesntExistPetIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            PetCertificatesQuery query = new(_context, _mapper);
            query.PetId = 0;

            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Evcil hayvan bulunamadı!");
        }

        [Fact]
        public void WhenAlreadyExistPetIdIsGiven_PetCertificates_ShouldBeReturn()
        {
            PetCertificatesQuery query = new(_context, _mapper);
            query.PetId = 1;

            var result = FluentActions.Invoking(() => query.Handle()).Invoke();

            result.Should().NotBeNull();
        }
    }
}
