using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.UserOperations.Queries.GetUsers
{
    public class GetUsersQuery
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUsersQuery(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<UserViewModel> Handle()
        {
            var users = _dbContext.Users.ToList<User>();

            var vm = _mapper.Map<List<UserViewModel>>(users);

            return vm;
        }
    }

    public class UserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
