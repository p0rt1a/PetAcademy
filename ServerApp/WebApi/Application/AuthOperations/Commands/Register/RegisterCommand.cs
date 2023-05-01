using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.AuthOperations.Commands.Register
{
    public class RegisterCommand
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;

        public RegisterCommand(IAcademyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            //TODO: Register user with using mapper
        }
    }

    public class RegisterModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
