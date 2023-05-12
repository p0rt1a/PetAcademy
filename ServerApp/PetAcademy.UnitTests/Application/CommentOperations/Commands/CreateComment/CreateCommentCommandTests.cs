using AutoMapper;
using FluentAssertions;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.CommentOperations.Commands.CreateComment;
using WebApi.DbOperations;
using Xunit;

namespace PetAcademy.UnitTests.Application.CommentOperations.Commands.CreateComment
{
    public class CreateCommentCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public CreateCommentCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenDoesNotExistUserIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            CreateCommentCommand command = new(_context, _mapper);
            command.Model = new CreateCommentModel()
            {
                Body = "WhenUserIdDoesNotExist_InvalidOperationException_ShouldBeReturn",
                UserId = 0,
                TrainingId = 1
            };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kullanıcı bulunamadı");
        }

        [Fact]
        public void WhenDoesNotExistTrainingIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            CreateCommentCommand command = new(_context, _mapper);
            command.Model = new CreateCommentModel()
            {
                Body = "WhenDoesNotExistTrainingIdIsGiven_InvalidOperationException_ShouldBeReturn",
                UserId = 1,
                TrainingId = 0
            };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Eğitim bulunamadı");
        }

        [Fact]
        public void WhenAlreadyExistTrainingIdAndUserIdAreGiven_Comment_ShouleBeCreated()
        {
            CreateCommentCommand command = new(_context, _mapper);
            command.Model = new CreateCommentModel()
            {
                Body = "WhenAlreadyExistTrainingIdAndUserIdAreGiven_Comment_ShouleBeCreated",
                UserId = 1,
                TrainingId = 3
            };

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var comment = _context.Comments.SingleOrDefault(x => x.UserId == 1 && x.TrainingId == 3);
            comment.Body.Should().Be("WhenAlreadyExistTrainingIdAndUserIdAreGiven_Comment_ShouleBeCreated");
            comment.UserId.Should().Be(1);
            comment.TrainingId.Should().Be(3);
        }
    }
}
