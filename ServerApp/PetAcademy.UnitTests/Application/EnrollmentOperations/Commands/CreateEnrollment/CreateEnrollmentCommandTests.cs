using AutoMapper;
using FluentAssertions;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment;
using WebApi.DbOperations;
using Xunit;

namespace PetAcademy.UnitTests.Application.EnrollmentOperations.Commands.CreateEnrollment
{
    public class CreateEnrollmentCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public CreateEnrollmentCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenPetGenreDoesntMatchWithTrainingGenre_InvalidOperationException_ShouldBeReturn()
        {
            var pet = _context.Pets.FirstOrDefault(x => x.GenreId == 1);
            var training = _context.Trainings.FirstOrDefault(x => x.GenreId == 2);

            CreateEnrollmentCommand command = new(_context, _mapper);
            command.Model = new CreateEnrollmentModel()
            {
                PetId = pet.Id,
                TrainingId = training.Id
            };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Evcil hayvan türü, eğitim türü için uygun değil.");
        }

        [Fact]
        public void WhenGivenPetIsAlreadyExistInGivenTraining_InvalidOperationException_ShouldBeReturn()
        {
            CreateEnrollmentCommand command = new(_context, _mapper);
            command.Model = new CreateEnrollmentModel()
            {
                PetId = 1,
                TrainingId = 1
            };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Evcil hayvan zaten bu eğitimde mevcut.");
        }

        [Fact]
        public void WhenGivenPetIdDoesNotExistTrainingWhichIsAlreadyExists_Enrollment_SouldBeCreated()
        {
            CreateEnrollmentCommand command = new(_context, _mapper);
            command.Model = new CreateEnrollmentModel()
            {
                PetId = 2,
                TrainingId = 6
            };

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var enrollment = _context.Enrollments.SingleOrDefault(x => x.PetId == command.Model.PetId && x.TrainingId == command.Model.TrainingId);
            enrollment.PetId.Should().Be(command.Model.PetId);
            enrollment.TrainingId.Should().Be(command.Model.TrainingId);
        }
    }
}
