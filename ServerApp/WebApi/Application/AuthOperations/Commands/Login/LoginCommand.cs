using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
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

        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);

            if (user is null)
                throw new InvalidOperationException("Email ya da şifre hatalı");

            //TODO: Set user's token properties
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
