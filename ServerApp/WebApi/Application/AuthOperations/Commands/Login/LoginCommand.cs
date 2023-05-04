using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.AuthOperations.Commands.Login
{
    public class LoginCommand
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public LoginModel Model { get; set; }

        public LoginCommand(IAcademyDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);

            if (user is null)
                throw new InvalidOperationException("Email ya da şifre hatalı");

            TokenHandler tokenHandler = new(_configuration);
            Token token = tokenHandler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.ExpirationDate.AddMinutes(45);

            _dbContext.SaveChanges();

            return token;
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
