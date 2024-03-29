﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.UserOperations.Queries.GetPets
{
    public class GetPetsQuery
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public int UserId { get; set; }

        public GetPetsQuery(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<UserPetViewModel> Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == UserId);

            if (user is null)
                throw new InvalidOperationException("Kullanıcı mevcut değil!");

            var pets = _dbContext.Pets
                .Include(x => x.Genre)
                .Where(x => x.UserId == UserId)
                .Where(x => x.IsActive)
                .ToList<Pet>();

            var vm = _mapper.Map<List<UserPetViewModel>>(pets);

            return vm;
        }
    }

    public class UserPetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
    }
}
