using AutoMapper;
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

        public List<PetViewModel> Handle()
        {
            var pets = _dbContext.Pets
                .Include(x => x.Genre)
                .Where(x => x.UserId == UserId)
                .ToList<Pet>();

            var vm = _mapper.Map<List<PetViewModel>>(pets);

            return vm;
        }
    }

    public class PetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
    }
}
