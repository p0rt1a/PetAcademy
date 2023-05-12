using AutoMapper;
using FluentAssertions;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.PetOperations.Commands.UpdatePet;
using WebApi.DbOperations;
using Xunit;

namespace PetAcademy.UnitTests.Application.PetOperations.Command.UpdatePet
{
    public class UpdatePetCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public UpdatePetCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenDoesNotExistUserIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            UpdatePetCommand command = new(_context, _mapper);
            command.PetId = 1;
            command.Model = new UpdatePetModel()
            {
                Name = "WhenDoesNotExistUserIdIsGiven_InvalidOperationException_ShouldBeReturnError",
                Age = 2,
                UserId = 0
            };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kullanıcı bulunamadı");
        }

        [Fact]
        public void WhenDoesNotExistPetIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            UpdatePetCommand command = new(_context, _mapper);
            command.PetId = 0;
            command.Model = new UpdatePetModel()
            {
                Name = "WhenDoesNotExistUserIdIsGiven_InvalidOperationException_ShouldBeReturnError",
                Age = 2,
                UserId = 1
            };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Evcil hayvan bulunamadı");
        }

        [Fact]
        public void WhenGivenUserIdPetsDoesNotIncludeGivenPetId_InvalidOperationException_ShouldBeReturnError()
        {
            UpdatePetCommand command = new(_context, _mapper);
            command.PetId = 1;
            command.Model = new UpdatePetModel()
            {
                Name = "WhenGivenUserIdPetsDoesNotIncludeGivenPetId_InvalidOperationException_ShouldBeReturnError",
                Age = 2,
                UserId = 2
            };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Evcil hayvan başka bir kullanıcıya ait");
        }

        [Fact]
        public void WhenAlreadyPetIdIsGiven_Pet_ShouldBeUpdated()
        {
            UpdatePetCommand command = new(_context, _mapper);
            command.PetId = 1;
            command.Model = new UpdatePetModel()
            {
                Name = "WhenAlreadyPetIdIsGiven_Pet_ShouldBeUpdated",
                Age = 2,
                UserId = 1
            };

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var pet = _context.Pets.SingleOrDefault(x => x.Name == "WhenAlreadyPetIdIsGiven_Pet_ShouldBeUpdated");
            pet.Name.Should().Be("WhenAlreadyPetIdIsGiven_Pet_ShouldBeUpdated");
            pet.Age.Should().Be(2);
        }
    }
}
