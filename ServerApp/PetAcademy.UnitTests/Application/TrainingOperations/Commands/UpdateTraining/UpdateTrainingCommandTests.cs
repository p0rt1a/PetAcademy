using AutoMapper;
using FluentAssertions;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.TrainingOperations.Commands.UpdateTraining;
using WebApi.DbOperations;
using Xunit;

namespace PetAcademy.UnitTests.Application.TrainingOperations.Commands.UpdateTraining
{
    public class UpdateTrainingCommandTests  :IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTrainingCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenDoesNotExistTrainingIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateTrainingCommand command = new(_context);
            command.TrainingId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek eğitim bulunamadı");
        }

        [Fact]
        public void WhenAlreadyExistTrainingIdIsGiven_Training_ShouldBeUpdated()
        {
            UpdateTrainingCommand command = new(_context);
            command.TrainingId = 1;

            command.Model = new UpdateTrainingModel()
            {
                Description = "WhenAlreadyExistTrainingIdIsGiven_Training_ShouldBeUpdated",
                Price = 200,
                MaxPetCount = 1
            };

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var training = _context.Trainings.SingleOrDefault(x => x.Id == command.TrainingId);
            training.Description.Should().Be("WhenAlreadyExistTrainingIdIsGiven_Training_ShouldBeUpdated");
            training.Price.Should().Be(200);
            training.MaxPetCount.Should().Be(1);
        }
    }
}
