using AutoMapper;
using FluentAssertions;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.UserOperations.Commands.UpdateUser;
using WebApi.DbOperations;
using Xunit;

namespace PetAcademy.UnitTests.Application.UserOperations.Commands.UpdateUser
{
    public class UpdateUserCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUserCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenDoesNotExistUserIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateUserCommand command = new(_context);
            command.UserId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kullanıcı bulunamadı");
        }

        [Fact]
        public void WhenAlreadyExistUserIdIsGiven_User_ShouldBeUpdated()
        {
            UpdateUserCommand command = new(_context);
            command.UserId = 1;
            command.Model = new UpdateUserModel()
            {
                Email = "WhenAlreadyExistUserIdIsGiven_User_ShouldBeUpdated@hotmail.com"
            };
            
            FluentActions.Invoking(() => command.Handle()).Invoke();

            var user = _context.Users.SingleOrDefault(x => x.Id == command.UserId);
            user.Email.Should().Be("WhenAlreadyExistUserIdIsGiven_User_ShouldBeUpdated@hotmail.com");
        }
    }
}
