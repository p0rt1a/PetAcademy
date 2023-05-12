using AutoMapper;
using FluentAssertions;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.TrainingOperations.Commands.DeleteTraining;
using WebApi.DbOperations;
using Xunit;

namespace PetAcademy.UnitTests.Application.TrainingOperations.Commands.DeleteTraining
{
    public class DeleteTrainingCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public DeleteTrainingCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenDoesNotExistTrainingIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            DeleteTrainingCommand command = new(_context);
            command.TrainingId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek eğitim bulunamadı");
        }

        [Fact]
        public void WhenAlreadyExistTrainingIdIsGiven_Training_ShouldBeDeleted()
        {
            DeleteTrainingCommand command = new(_context);
            command.TrainingId = _context.Trainings.Count();

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var training = _context.Trainings.SingleOrDefault(x => x.Id == command.TrainingId);
            training.Should().BeNull();
        }
    }
}
