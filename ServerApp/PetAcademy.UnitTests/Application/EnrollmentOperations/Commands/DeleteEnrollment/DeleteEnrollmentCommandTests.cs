using AutoMapper;
using FluentAssertions;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.EnrollmentOperations.Commands.DeleteEnrollment;
using WebApi.DbOperations;
using WebApi.Entities;
using Xunit;

namespace PetAcademy.UnitTests.Application.EnrollmentOperations.Commands.DeleteEnrollment
{
    public class DeleteEnrollmentCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public DeleteEnrollmentCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenPetDoesntHaveEnrollmentWithTraining_InvalidOperationException_ShouldBeReturn()
        {
            DeleteEnrollmentCommand command = new(_context, _mapper);
            command.PetId = 1;
            command.TrainingId = 3;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Evcil hayvan bu eğitime kayıtlı değil!");
        }
    }
}
