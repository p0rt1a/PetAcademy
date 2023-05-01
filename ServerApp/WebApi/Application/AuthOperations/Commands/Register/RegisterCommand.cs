using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthOperations.Commands.Register
{
    public class RegisterCommand
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public RegisterModel Model { get; set; }

        public RegisterCommand(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Email == Model.Email);

            if (user is not null)
                throw new InvalidOperationException("Kullanıcı zaten mevcut");

            user = _mapper.Map<User>(Model);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
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
