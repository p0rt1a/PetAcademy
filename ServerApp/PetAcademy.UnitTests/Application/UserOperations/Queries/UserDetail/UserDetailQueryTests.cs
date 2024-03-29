﻿using AutoMapper;
using FluentAssertions;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.UserOperations.Queries.UserDetail;
using WebApi.DbOperations;
using Xunit;

namespace PetAcademy.UnitTests.Application.UserOperations.Queries.UserDetail
{
    public class UserDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public UserDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenDoesNotExistUserIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UserDetailQuery query = new(_context, _mapper);
            query.UserId = 0;

            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kullanıcı mevcut değil!");
        }

        [Fact]
        public void WhenAlreadyExistUserIdIsGiven_User_ShouldBeReturn()
        {
            UserDetailQuery query = new(_context, _mapper);
            query.UserId = 1;

            var result = FluentActions.Invoking(() => query.Handle()).Invoke();

            result.Should().NotBeNull();
        }
    }
}
