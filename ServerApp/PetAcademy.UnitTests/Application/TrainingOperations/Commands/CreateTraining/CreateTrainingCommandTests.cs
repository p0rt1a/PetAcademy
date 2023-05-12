using AutoMapper;
using FluentAssertions;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.TrainingOperations.Commands.CreateTraining;
using WebApi.DbOperations;
using Xunit;

namespace PetAcademy.UnitTests.Application.TrainingOperations.Commands.CreateTraining
{
    public class CreateTrainingCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public CreateTrainingCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenDoesNotExistGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            CreateTrainingCommand command = new(_context, _mapper);
            command.Model = new CreateTrainingModel()
            {
                Title = "New Training",
                Description = "Lorem ipsum dolor sit amet.",
                City = "İstanbul",
                Address = "XXX Mahallesi",
                Price = 200,
                MaxPetCount = 10,
                GenreId = 0,
                UserId = 1
            };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre bulunamadı");
        }

        [Fact]
        public void WhenAlreadyExistGenreIdIsGiven_Training_ShouldBeCreated()
        {
            CreateTrainingCommand command = new(_context, _mapper);
            command.Model = new CreateTrainingModel()
            {
                Title = "New Training",
                Description = "Lorem ipsum dolor sit amet.",
                City = "İstanbul",
                Address = "XXX Mahallesi",
                Price = 200,
                MaxPetCount = 10,
                GenreId = 1,
                UserId = 1
            };

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var training = _context.Trainings.SingleOrDefault(x => x.Title == command.Model.Title);
            training.Should().NotBeNull();
        }
    }
}
