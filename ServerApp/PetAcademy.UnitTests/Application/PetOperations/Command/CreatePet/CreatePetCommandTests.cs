using AutoMapper;
using FluentAssertions;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.PetOperations.Commands.CreatePet;
using WebApi.DbOperations;
using Xunit;

namespace PetAcademy.UnitTests.Application.PetOperations.Command.CreatePet
{
    public class CreatePetCommandTests  :IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public CreatePetCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenDoesNotExistUserIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            CreatePetCommand command = new(_context, _mapper);
            command.Model = new CreatePetModel()
            {
                Name = "WhenDoesNotExistUserIdIsGiven_InvalidOperationException_ShouldBeReturn",
                Age = 8,
                GenreId = 1,
                UserId = 0
            };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kullanıcı mevcut değil");
        }

        [Fact]
        public void WhenDoesNotExistGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            CreatePetCommand command = new(_context, _mapper);
            command.Model = new CreatePetModel()
            {
                Name = "WhenDoesNotExistGenreIdIsGiven_InvalidOperationException_ShouldBeReturn",
                Age = 8,
                GenreId = 0,
                UserId = 1
            };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Tür mevcut değil");
        }

        [Fact]
        public void WhenAlreadyExistIdsAreGiven_Pet_ShouldBeCreated()
        {
            CreatePetCommand command = new(_context, _mapper);
            command.Model = new CreatePetModel()
            {
                Name = "WhenAlreadyExistIdsAreGiven_Pet_ShouldBeCreated",
                Age = 2,
                GenreId = 1,
                UserId = 1
            };

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var pet = _context.Pets.SingleOrDefault(x => x.Name == "WhenAlreadyExistIdsAreGiven_Pet_ShouldBeCreated");
            pet.Name.Should().Be("WhenAlreadyExistIdsAreGiven_Pet_ShouldBeCreated");
            pet.Age.Should().Be(2);
            pet.GenreId.Should().Equals(1);
            pet.UserId.Should().Equals(1);
        }
    }
}
