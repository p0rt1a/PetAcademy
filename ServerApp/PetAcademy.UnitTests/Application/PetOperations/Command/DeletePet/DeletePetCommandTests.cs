using AutoMapper;
using FluentAssertions;
using FluentValidation;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.PetOperations.Commands.DeletePet;
using WebApi.DbOperations;
using WebApi.Entities;
using Xunit;

namespace PetAcademy.UnitTests.Application.PetOperations.Command.DeletePet
{
    public class DeletePetCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;

        public DeletePetCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenDoesNotExistPetIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            DeletePetCommand command = new(_context);
            command.PetId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Evcil hayvan bulunamadı!");
        }

        [Fact]
        public void WhenAlreadyExistPetIdIsGiven_Pet_ShouldBeDeleted()
        {
            var newPet = new Pet()
            {
                Age = 2,
                GenreId = 1,
                Name = "WhenAlreadyExistPetIdIsGiven_Pet_ShouldBeDeleted",
                UserId = 1
            };

            DeletePetCommand command = new(_context);
            command.PetId = _context.Pets.Count();

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var pet = _context.Pets.SingleOrDefault(x => x.Id == command.PetId);
            pet.Should().BeNull();
        }
    }
}
